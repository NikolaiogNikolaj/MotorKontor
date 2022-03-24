using MotorKontor.BL.Models;

namespace MotorKontor.BL.Models.DTO
{
    public class RegistrationDTO
    {
        public string CarManufacturer { get; set; }
        public string CarModel { get; set; }
        public DateTime VehicleRegistrationDate { get; set; }
        public Fuel FuelType { get; set; }
    }
}
