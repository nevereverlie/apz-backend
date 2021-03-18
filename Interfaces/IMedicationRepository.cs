using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Models.OAS;

namespace Apz_backend.Interfaces
{
    public interface IMedicationRepository
    {
         Task<IEnumerable<OasMedication>> GetMedications();
         Task<OasMedication> GetMedicationById(int medicationId);
         Task AddMedication(OasMedication medication);
         Task UpdateMedication(OasMedication medication);
         Task DeleteMedication(int medicationId);
    }
}