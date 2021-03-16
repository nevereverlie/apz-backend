using Apz_backend.Models.DB;

namespace Revisory_Control.API.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(User user);
    }
}