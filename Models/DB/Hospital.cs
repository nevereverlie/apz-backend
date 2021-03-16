using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apz_backend.Models.DB;

namespace Apz_backend.Models
{
    public class Hospital
    {
        [Required]
        public int HospitalId { get; set; }
        [Required]
        public string HospitalName { get; set; }
        public ICollection<Animal> HospitalAnimals { get; set; }
        public ICollection<User> Users { get; set; }
    }
}