using MotorKontor.BL.Models;

namespace MotorKontor.BL.Models.DTO
{
    public class VehicleDTO
    {
        public string VehicleModel { get; set; }
        public Fuel Fuel { get; set; }
        public int LeaseMonths { get; set; }
    }
}
