using MotorKontor.BL.Models;

namespace MotorKontor.BL.Models.DTO
{
    public class VehicleDTO
    {
        public string CarManufacturer { get; set; }
        public string CarModel { get; set; }
        public DateTime VehicleRegistrationDate { get; set; }
        public Fuel FuelType { get; set; }
    }
}
