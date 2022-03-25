using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MotorKontor.UI.Models
{
    public class Vehicle
    {
        public Vehicle() { }

        [Key]
        public int VehicleID { get; set; }
        public string? CarManufacturer { get; set; }
        public string? CarModel { get; set; }
        public DateTime VehicleRegistrationDate { get; set; }
        public Fuel FuelType { get; set; }


        public Vehicle(string createdby, string model, DateTime boughtat, Fuel fuel)
        {
            CarManufacturer = createdby;
            CarModel = model;
            VehicleRegistrationDate = boughtat;
            FuelType = fuel;
        }
    }
}
