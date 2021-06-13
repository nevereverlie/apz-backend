using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Apz_backend.Models.DB;
using Apz_backend.Models.OAS;
using Apz_backend.Models.Parameters;

namespace Apz_backend.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ITokenService _tokenService;
        private readonly IUserDbStorage _users;
        private readonly IAppRepository _appRepository;
        public AuthRepository(
            ITokenService tokenService,
            IUserDbStorage users,
            IAppRepository appRepository)
        {
            _tokenService = tokenService;
            _users = users;
            _appRepository = appRepository;
        }
        public async Task<OasLogonUser> Login(LogonParameters logonParameters)
        {
            var user = await _users.GetUserByEmail(logonParameters.Email);

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logonParameters.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }
            
            return new OasLogonUser
            {
                UserId = user.UserId,
                UserEmail = user.UserEmail,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<OasLogonUser> Register(LogonParameters logonParameters)
        {
            if (await UserExists(logonParameters.Email)) return null;

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Lastname = logonParameters.Lastname,
                Firstname = logonParameters.Firstname,
                UserEmail = logonParameters.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logonParameters.Password)),
                PasswordSalt = hmac.Key,
                HospitalId = 1
            };

            _appRepository.Add(user);

            await _appRepository.SaveChangesAsync();

            return new OasLogonUser
            {
                UserId = user.UserId,
                UserEmail = user.UserEmail,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<bool> UserExists(string userEmail)
        {
            var user = await _users.GetUserByEmail(userEmail);

            return user == null ? false : true;
        }
    }
}