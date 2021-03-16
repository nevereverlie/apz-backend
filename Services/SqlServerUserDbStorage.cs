using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Apz_backend.Data;
using Apz_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Apz_backend.Models.DB;

namespace Apz_backend.Services
{
    public class SqlServerUserDbStorage : IUserDbStorage
    {
        private readonly DataContext _context;
        public SqlServerUserDbStorage(DataContext context)
        {
            _context = context;
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
    }
}