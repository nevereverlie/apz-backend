using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apz_backend.Models
{
    public class Animal
    {
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public string AnimalType { get; set; }
        [Required]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public string AnimalName { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}