using System.ComponentModel.DataAnnotations;

namespace Apz_backend.Models
{
    public class Schedule
    {
        [Required]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        [Required]
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
        public string Description { get; set; }
    }
}