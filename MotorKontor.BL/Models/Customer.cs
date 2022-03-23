using MotorKontor.BL.Models.JWT;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.BL.Models
{
    public class Customer
    {
        public Customer(){}
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Cpr { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        //JWT
        //JWT properties
        public string Username { get; set; }
        public string Password { get; set; }

        public List<RefreshToken>? RefreshToken { get; set; }

        //navigation property - dette skaber et 1-M forhold
        public ICollection<Registration> Registrations { get; set; }
        //CTOR
        public Customer(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public Customer(string firstname, string lastname, int cpr)
        {
            Firstname = firstname;
            Lastname = lastname;
            Cpr = cpr;
            CreatedDate = DateTime.Now;
        }
    }
}
