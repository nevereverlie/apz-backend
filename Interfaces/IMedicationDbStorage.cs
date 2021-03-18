using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Models;

namespace Apz_backend.Interfaces
{
    public interface IMedicationDbStorage
    {
         Task<IEnumerable<Medication>> GetMedications();
         Task<Medication> GetMedicationById(int medicationId);
         Task AddMedication(Medication medication);
         Task UpdateMedication(Medication medication);
         Task DeleteMedication(int medicationId);    
    }
}