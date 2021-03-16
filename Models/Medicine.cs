using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apz_backend.Models
{
    public class Medicine
    {
        [Required]
        public int MedicineId { get; set; }
        [Required]
        public string MedicineName { get; set; }
        public ICollection<Medication> Medications { get; set; }
    }
}