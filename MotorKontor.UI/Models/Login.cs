using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.UI.Models
{
    public class Login
    {
        public Login() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? LoginID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
