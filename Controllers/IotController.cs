using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Apz_backend.Interfaces;
using System.IO;

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
            [FromBody]byte[] animalImageByteArray,
            [FromRoute] string animalType)
        {
            using var ms = new MemoryStream(animalImageByteArray);
            Image animalImage = Image.FromStream(ms);

            return Ok(await _distanceDetectionService.IsAppropriateDistance(animalImage, animalType));
        }
    }
}