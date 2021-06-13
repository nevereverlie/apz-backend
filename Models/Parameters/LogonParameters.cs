namespace Apz_backend.Models.Parameters
{
    public class LogonParameters
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; } = "-";
        public string Lastname { get; set; } = "-";
    }
}