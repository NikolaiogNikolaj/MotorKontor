using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.BL.Models
{
    public class Login
    {
        public Login() { }
        [Key]
        public int? LoginID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
