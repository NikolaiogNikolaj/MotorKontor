using MotorKontor.UI.Models.JWT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.UI.Models
{
    public class Customer
    {
        public Customer() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CustomerID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNr { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? UserCreation { get; set; }
        //public virtual Address UserAddress { get; set; }
        public virtual List<Vehicle>? UserVehicles { get; set; }
        public virtual List<RefreshToken>? RefreshToken { get; set; }

        public Customer(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Customer(string username, string password, string firstname, string lastname, string email, string phonenr)
        {
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PhoneNr = phonenr;
            UserCreation = DateTime.Now;
            UserVehicles = new List<Vehicle>();
        }
    }
}
