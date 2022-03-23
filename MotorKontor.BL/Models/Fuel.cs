using System.ComponentModel.DataAnnotations;

namespace MotorKontor.BL.Models
{
    public class Fuel
    {        
        public Fuel() { }

        public int FuelId { get; set; }
        [Required]
        public string FuelName { get; set; }

    }
}
