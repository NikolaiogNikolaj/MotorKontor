using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MotorKontor.UI.Models
{
    public class Registration
    {
        public Registration() { }

        [Key]
        public int? RegistrationID { get; set; }
        public string? CarModel { get; set; }
        public DateTime RegistratedStart { get; set; }
        public DateTime RegistratedEnding { get; set; }
        public Fuel FuelType { get; set; }
        public int? CustomerID { get; set; }
        public int? VehicleID { get; set; }



        public Registration(string? model, int leasingMonths, Fuel fueltype, int customerid, int vehicleid)
        {
            CarModel = model;
            RegistratedStart = DateTime.UtcNow;
            RegistratedEnding = RegistratedStart.AddMonths(leasingMonths);
            FuelType = fueltype;
            CustomerID = customerid;
            VehicleID = vehicleid;
        }
    }
}
