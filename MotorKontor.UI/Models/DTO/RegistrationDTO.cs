using MotorKontor.UI.Models;

namespace MotorKontor.UI.Models.DTO
{
    public class RegistrationDTO
    {
        public int? RegistrationID { get; set; }
        public string? CarModel { get; set; }
        public int? LeasingVehicles { get; set; }
        public Fuel FuelType { get; set; }
    }
}
