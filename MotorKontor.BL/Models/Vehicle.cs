using System.ComponentModel.DataAnnotations;

namespace MotorKontor.BL.Models
{
    public class Vehicle
    {
        public Vehicle() {
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        //Foreign keys
        

        //Navigational properties
        public Fuel Fuel { get; set; } // 1-1, 1 customer per registration

    }
}
