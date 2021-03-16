using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apz_backend.Models
{
    public class Medication
    {
        [Required]
        public int MedicationId { get; set; }
        [Required]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        [Required]
        public int MedicationAmount { get; set; }
        [Required]
        public string MedicationType { get; set; }
        [Required]
        public DateTime MedicationTime { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}