using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Apz_backend.Interfaces;

namespace Apz_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IotController : ControllerBase
    {
        private readonly IDistanceDetectionService _distanceDetectionService;
        public IotController(IDistanceDetectionService distanceDetectionService)
        {
            _distanceDetectionService = distanceDetectionService;
        }

        [HttpPost("detectDistance/{animalType}")]
        public async Task<IActionResult> DetectDistance(
            IFormFile imageFile,
            [FromRoute] string animalType)
        {
            Image animalImage = Image.FromStream(imageFile.OpenReadStream(), true, true);
            
            return Ok(await _distanceDetectionService.IsAppropriateDistance(animalImage, animalType));
        }
    }
}