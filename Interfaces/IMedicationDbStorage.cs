using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Models;
using Apz_backend.Models.OAS;

namespace Apz_backend.Interfaces
{
    public interface IMedicationDbStorage
    {
        Task<IEnumerable<OasMedication>> GetMedications();
         Task<IEnumerable<OasMedication>> GetMedicationsForUser(int userId);
         Task<Medication> GetMedicationById(int medicationId);
         Task AddMedication(OasMedication medication);
         Task UpdateMedication(OasMedication medication);
         Task DeleteMedication(int medicationId);    
    }
}