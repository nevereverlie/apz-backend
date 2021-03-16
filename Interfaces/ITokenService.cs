using Apz_backend.Models.DB;

namespace Apz_backend.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(User user);
    }
}