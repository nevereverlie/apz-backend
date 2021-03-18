using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Data;
using Apz_backend.Interfaces;
using Apz_backend.Models;
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

        public async Task<IEnumerable<Medication>> GetMedications()
        {
            return await _context.Medications.ToListAsync();
        }

        public async Task<Medication> GetMedicationById(int medicationId)
        {
            return await _context.Medications.FirstOrDefaultAsync(m => m.MedicationId == medicationId);
        }

        public async Task AddMedication(Medication medication)
        {
            if (medication != null)
            {
                _appRepository.Add(medication);
                await _appRepository.SaveChangesAsync();
            }
        }

        public async Task UpdateMedication(Medication medication)
        {
            Medication medicationToUpdate = await _context.Medications.FirstOrDefaultAsync(m => m.MedicationId == medication.MedicationId);

            if (medicationToUpdate != null)
            {
                medicationToUpdate.MedicineId = medication.MedicineId;
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