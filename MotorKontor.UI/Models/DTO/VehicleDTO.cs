using MotorKontor.UI.Models;

namespace MotorKontor.UI.Models.DTO
{
    public class VehicleDTO
    {
        public string VehicleModel { get; set; }
        public Fuel Fuel { get; set; }
        public int LeaseMonths { get; set; }
    }
}
