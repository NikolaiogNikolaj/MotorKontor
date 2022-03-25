using MotorKontor.BL.Models;

namespace MotorKontor.BL.Models.DTO
{
    public class RegistrationDTO
    {
        public int? RegistrationID { get; set; }
        public string? CarModel { get; set; }
        public int? LeasingVehicles { get; set; }
        public Fuel FuelType { get; set; }
    }
}
