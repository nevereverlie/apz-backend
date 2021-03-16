using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Apz_backend.Models
{
    public class Hospital
    {
        [Required]
        public int HospitalId { get; set; }
        [Required]
        public string HospitalName { get; set; }
        public ICollection<Animal> HospitalAnimals { get; set; }
    }
}