using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.UI.Models
{
    public class Registration
    {
        public Registration() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RegistrationID { get; set; }
        public string? CarManufacturer { get; set; }
        public string? CarModel { get; set; }
        public DateTime? VehicleRegistrationDate { get; set; }
        public Fuel? FuelType { get; set; }

        public Registration(string carmanufacturer, string model, DateTime created, Fuel fueltype)
        {
            CarManufacturer = carmanufacturer;
            CarModel = model;
            VehicleRegistrationDate = created;
            FuelType = fueltype;

        }
    }
}
