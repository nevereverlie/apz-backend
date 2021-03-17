using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Apz_backend.Models.DB;
using Apz_backend.Models.OAS;
using AutoMapper;

namespace Apz_backend.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDbStorage _userDbStorage;
        private readonly IMapper _mapper;
        public UserRepository(
            IUserDbStorage userDbStorage,
            IMapper mapper)
        {
            _userDbStorage = userDbStorage;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OasUser>> GetUsers()
        {
            var usersToReturn = await _userDbStorage.GetUsers();

            return _mapper.Map<IEnumerable<OasUser>>(usersToReturn);
        }
        public async Task<OasUser> GetUserById(int id)
        {
            var userToReturn = await _userDbStorage.GetUserById(id);

            return _mapper.Map<OasUser>(userToReturn);
        }
        public async Task<OasUser> GetUserByEmail(string email)
        {
            var userToReturn = await _userDbStorage.GetUserByEmail(email);

            return _mapper.Map<OasUser>(userToReturn);
        }

        public async Task UpdateUser(OasUser user)
        {
            User userToUpdate = new User
            {
                UserId = user.UserId,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                UserEmail = user.UserEmail,
                HospitalId = user.HospitalId
            };

            await _userDbStorage.UpdateUser(userToUpdate);
        }

        public async Task DeleteUser(int userId)
        {
            await _userDbStorage.DeleteUser(userId);
        }
    }
}