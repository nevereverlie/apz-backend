using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apz_backend.Data;
using Apz_backend.Interfaces;
using Apz_backend.Models;
using Apz_backend.Models.OAS;
using Microsoft.EntityFrameworkCore;

namespace Apz_backend.Services
{
    public class SqlServerMedicationsDbStorage : IMedicationDbStorage
    {
        private readonly DataContext _context;
        private readonly IAppRepository _appRepository;
        public SqlServerMedicationsDbStorage(
            DataContext context,
            IAppRepository appRepository)
        {
            _context = context;
            _appRepository = appRepository;
        }

        public async Task<IEnumerable<OasMedication>> GetMedications()
        {
            var medicationsFromDb = await _context.Medications.ToListAsync();

            var result = new List<OasMedication>();
            foreach (Medication medication in medicationsFromDb)
            {
                var medicineName = await _context.Medicines
                    .Where(m => m.MedicineId == medication.MedicineId)
                    .FirstOrDefaultAsync();

                OasMedication medicationToAdd = new OasMedication 
                {
                    MedicationId = medication.MedicationId,
                    MedicationAmount = medication.MedicationAmount,
                    MedicationTime = medication.MedicationTime,
                    MedicationType = medication.MedicationType,
                    MedicineName = medicineName.MedicineName,
                    UserId = medication.UserId
                };

                result.Add(medicationToAdd);
            }

            return result;
        }

        public async Task<IEnumerable<OasMedication>> GetMedicationsForUser(int userId)
        {
            var medicationsFromDb = await _context.Medications.Where(m => m.UserId == userId).ToListAsync();

            var result = new List<OasMedication>();
            foreach (Medication medication in medicationsFromDb)
            {
                var medicineName = await _context.Medicines
                    .Where(m => m.MedicineId == medication.MedicineId)
                    .FirstOrDefaultAsync();

                OasMedication medicationToAdd = new OasMedication 
                {
                    MedicationId = medication.MedicationId,
                    MedicationAmount = medication.MedicationAmount,
                    MedicationTime = medication.MedicationTime,
                    MedicationType = medication.MedicationType,
                    MedicineName = medicineName.MedicineName,
                    UserId = medication.UserId
                };

                result.Add(medicationToAdd);
            }

            return result;
        }

        public async Task<Medication> GetMedicationById(int medicationId)
        {
            return await _context.Medications.FirstOrDefaultAsync(m => m.MedicationId == medicationId);
        }

        public async Task AddMedication(OasMedication medication)
        {
            var medicine = await _context.Medicines.FirstOrDefaultAsync(m => m.MedicineName == medication.MedicineName);

            Medication medicationToAdd = new Medication
            {
                MedicineId = medicine.MedicineId,
                UserId = medication.UserId,
                MedicationAmount = medication.MedicationAmount,
                MedicationTime = medication.MedicationTime,
                MedicationType = medication.MedicationType,
            };

            if (medicationToAdd != null)
            {
                _appRepository.Add(medicationToAdd);
                await _appRepository.SaveChangesAsync();
            }
        }

        public async Task UpdateMedication(OasMedication medication)
        {
            Medication medicationToUpdate = await _context.Medications.FirstOrDefaultAsync(m => m.MedicationId == medication.MedicationId);

            var medicine = await _context.Medicines
                .Where(m => m.MedicineName == medication.MedicineName)
                .FirstOrDefaultAsync();

            if (medicationToUpdate != null)
            {
                medicationToUpdate.MedicineId = medicine.MedicineId;
                medicationToUpdate.MedicationAmount = medication.MedicationAmount;
                medicationToUpdate.MedicationType = medication.MedicationType;
                medicationToUpdate.MedicationTime = medication.MedicationTime;

                _appRepository.Update(medicationToUpdate);
                await _appRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteMedication(int medicationId)
        {
            Medication medicationToDelete = await _context.Medications.FirstOrDefaultAsync(m => m.MedicationId == medicationId);

            if (medicationToDelete != null)
            {
                _appRepository.Delete(medicationToDelete);
                await _appRepository.SaveChangesAsync();
            }
        }
    }
}