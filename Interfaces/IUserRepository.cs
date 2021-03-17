using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Models.OAS;

namespace Apz_backend.Interfaces
{
    public interface IUserRepository
    {
         Task<IEnumerable<OasUser>> GetUsers();
         Task<OasUser> GetUserById(int id);
         Task<OasUser> GetUserByEmail(string email);
         Task UpdateUser(OasUser user);
         Task DeleteUser(int userId);
    }
}