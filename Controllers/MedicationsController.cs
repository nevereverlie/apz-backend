using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Apz_backend.Models.OAS;
using Microsoft.AspNetCore.Mvc;

namespace Apz_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MedicationsController(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedications()
        {
            return Ok(await _unitOfWork.Medications.GetMedications());
        }

        [HttpGet("{medicationId}")]
        public async Task<IActionResult> GetMedicationById([FromRoute] int medicationId)
        {
            return Ok(await _unitOfWork.Medications.GetMedicationById(medicationId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMedication([FromBody] OasMedication medicationToAdd)
        {
            await _unitOfWork.Medications.AddMedication(medicationToAdd);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMedication([FromBody] OasMedication medicationToUpdate)
        {
            await _unitOfWork.Medications.UpdateMedication(medicationToUpdate);

            return Ok();
        }

        [HttpDelete("delete/{medicationId}")]
        public async Task<IActionResult> DeleteMedication(int medicationId)
        {
            await _unitOfWork.Medications.DeleteMedication(medicationId);

            return Ok();
        }
    }
}