namespace Apz_backend.Models.OAS
{
    public class OasUser
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int HospitalId { get; set; }
    }
}