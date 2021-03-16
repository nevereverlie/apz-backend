using System.Threading.Tasks;
using Apz_backend.Models.OAS;
using Apz_backend.Models.Parameters;

namespace Apz_backend.Interfaces
{
    public interface IAuthRepository
    {
         Task<OasLogonUser> Login(LogonParameters logonParameters);
         Task<OasLogonUser> Register(LogonParameters logonParameters);
         Task<bool> UserExists(string userEmail);
    }
}