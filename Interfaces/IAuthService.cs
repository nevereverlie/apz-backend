using System.Threading.Tasks;
using Apz_backend.Models.OAS;
using Apz_backend.Models.Parameters;

namespace Apz_backend.API.Interfaces
{
    public interface IAuthService
    {
         Task<OasUser> Login(LogonParameters logonParameters);
         Task<OasUser> Register(LogonParameters logonParameters);
         Task<bool> UserExists(string userEmail);
    }
}