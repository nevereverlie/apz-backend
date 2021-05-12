using System.Collections.Generic;
using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Apz_backend.Models;
using Apz_backend.Models.OAS;
using AutoMapper;

namespace Apz_backend.Services
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly IMedicationDbStorage _medicationDbStorage;
        private readonly IMapper _mapper;
        public MedicationRepository(
            IMedicationDbStorage medicationDbStorage,
            IMapper mapper)
        {
            _medicationDbStorage = medicationDbStorage;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OasMedication>> GetMedications()
        {
            return await _medicationDbStorage.GetMedications();
        }

        public async Task<OasMedication> GetMedicationById(int medicationId)
        {
            var medicationToReturn = await _medicationDbStorage.GetMedicationById(medicationId);

            return _mapper.Map<OasMedication>(medicationToReturn);
        }

        public async Task AddMedication(OasMedication medication)
        {
            await _medicationDbStorage.AddMedication(medication);
        }

        public async Task UpdateMedication(OasMedication medication)
        {
            await _medicationDbStorage.UpdateMedication(medication);
        }

        public async Task DeleteMedication(int medicationId)
        {
            await _medicationDbStorage.DeleteMedication(medicationId);
        }
    }
}