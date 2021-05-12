using System;

namespace Apz_backend.Models.OAS
{
    public class OasMedication
    {
        public int MedicationId { get; set; }
        public string MedicineName { get; set; }
        public int MedicationAmount { get; set; }
        public string MedicationType { get; set; }
        public string MedicationTime { get; set; }
    }
}