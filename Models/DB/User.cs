using System.ComponentModel.DataAnnotations;

namespace Apz_backend.Models.DB
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; } 
    }
}