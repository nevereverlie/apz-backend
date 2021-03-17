using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Apz_backend.Models.OAS;
using Microsoft.AspNetCore.Mvc;

namespace Apz_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _unitOfWork.Users.GetUsers());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            return Ok(await _unitOfWork.Users.GetUserById(userId));
        }

        [HttpGet("byEmail/{userEmail}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string userEmail)
        {
            return Ok(await _unitOfWork.Users.GetUserByEmail(userEmail));
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] OasUser userToUpdate)
        {
            await _unitOfWork.Users.UpdateUser(userToUpdate);

            return Ok();
        }
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            await _unitOfWork.Users.DeleteUser(userId);

            return Ok();
        }
    }
}