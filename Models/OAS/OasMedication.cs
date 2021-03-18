using System;

namespace Apz_backend.Models.OAS
{
    public class OasMedication
    {
        public int MedicationId { get; set; }
        public int MedicineId { get; set; }
        public int MedicationAmount { get; set; }
        public string MedicationType { get; set; }
        public DateTime MedicationTime { get; set; }
    }
}