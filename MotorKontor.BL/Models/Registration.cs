using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.BL.Models
{
    public class Registration
    {
        //ctor
        public Registration(
            ) {
            DateRegistration = DateTime.Now;
        }
        [Key]
        public int RegistrationId { get; set; }
        [Required]
        public DateTime DateRegistration { get; set; }

        //Foreign Keys


        //Navigational properties
        public Customer Customer { get; set; } // 1-1, 1 customer per registration
        public Address Address { get; set; } // 1-1, 1 address per registration
        public Vehicle Vehicle { get; set; } // 1-1, 1 vehicle per registration




    }
}
