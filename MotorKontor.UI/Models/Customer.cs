using MotorKontor.UI.Models.JWT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.UI.Models
{
    public class Customer
    {
        public Customer() { }

        [Key]
        public int? CustomerID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNr { get; set; }
        public DateTime UserCreation { get; set; }
        public virtual Address? UserAddress { get; set; }
        public virtual List<Registration>? UserRegistratedVehicles { get; set; }
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
            UserRegistratedVehicles = new List<Registration>();
            RefreshToken = new List<RefreshToken>();
        }
    }
}
