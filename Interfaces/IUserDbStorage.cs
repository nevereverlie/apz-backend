using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Models.DB;

namespace Apz_backend.Interfaces
{
    public interface IUserDbStorage
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUserById(int id);
         Task<User> GetUserByEmail(string email);
         Task UpdateUser(User user);
         Task DeleteUser(int userId);
    }
}