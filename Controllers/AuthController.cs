using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Apz_backend.Models.OAS;
using Apz_backend.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Apz_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IAppRepository _appRepository;
        private readonly IAuthRepository _authRepository;

        public AuthController(IUserRepository userRepository,
                                 ITokenService tokenService,
                                 IAppRepository appRepository,
                                 IAuthRepository authRepository)
        {
            _tokenService = tokenService;
            _appRepository = appRepository;
            _authRepository = authRepository;
            _userRepository = userRepository;
        }


        [HttpPost("register")]
        public async Task<ActionResult<OasLogonUser>> Register(LogonParameters logonParameters)
        {
            if (await UserExists(logonParameters.Email)) return BadRequest("Email is taken");

            return await _authRepository.Register(logonParameters);
        }

        [HttpPost("login")]
        public async Task<ActionResult<OasLogonUser>> Login(LogonParameters logonParameters)
        {
            var user = await _userRepository.GetUserByEmail(logonParameters.Email);

            if (user == null) return Unauthorized("Invalid email");

            var userToLogin = await _authRepository.Login(logonParameters);

            if (userToLogin == null) return Unauthorized("Invalid password");

            return userToLogin;
        }

        private async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            return user == null ? false : true;
        }
    }
}