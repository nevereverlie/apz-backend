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
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost("register")]
        public async Task<ActionResult<OasLogonUser>> Register(LogonParameters logonParameters)
        {
            if (await UserExists(logonParameters.Email)) return BadRequest("Email is taken");

            return await _unitOfWork.Auth.Register(logonParameters);
        }

        [HttpPost("login")]
        public async Task<ActionResult<OasLogonUser>> Login(LogonParameters logonParameters)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(logonParameters.Email);

            if (user == null) return Unauthorized("Invalid email");

            var userToLogin = await _unitOfWork.Auth.Login(logonParameters);

            if (userToLogin == null) return Unauthorized("Invalid password");

            return userToLogin;
        }

        private async Task<bool> UserExists(string email)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(email);

            return user == null ? false : true;
        }
    }
}