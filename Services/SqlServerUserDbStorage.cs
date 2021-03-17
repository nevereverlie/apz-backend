using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Apz_backend.Models.DB;
using Apz_backend.Models.OAS;
using Apz_backend.Data;
using Apz_backend.Interfaces;
using AutoMapper;

namespace Apz_backend.Services
{
    public class SqlServerUserDbStorage : IUserDbStorage
    {
        private readonly DataContext _context;
        private readonly IAppRepository _appRepository;
        public SqlServerUserDbStorage(
            DataContext context,
            IAppRepository appRepository)
        {
            _context = context;
            _appRepository = appRepository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync(); 
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
        }
        public async Task UpdateUser(User user)
        {
            var updatedUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (updatedUser != null)
            {
                updatedUser.UserEmail = user.UserEmail;
                updatedUser.Lastname = user.Lastname;
                updatedUser.Firstname = user.Firstname;
                updatedUser.HospitalId = user.HospitalId;

                _appRepository.Update(updatedUser);

                await _appRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            var deletedUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (deletedUser != null)
            {
                _appRepository.Delete(deletedUser);

                await _appRepository.SaveChangesAsync();
            }
        }
    }
}