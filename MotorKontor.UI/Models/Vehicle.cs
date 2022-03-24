using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.UI.Models
{
    public class Vehicle
    {
        public Vehicle() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? VehicleID { get; set; }
        public string? VehicleModel { get; set; }
        public Fuel? Fuel { get; set; }
        public DateTime? LeasedStartDate { get; set; }
        public DateTime? LeasedEndDate { get; set; }


        public int? RegistrationID { get; set; }
        [ForeignKey("RegistrationID")]
        public virtual Registration? Registration { get; set; }

        public Vehicle(string model, Fuel? fuel, int leasemonths)
        {
            VehicleModel = model;
            Fuel = fuel;
            LeasedStartDate = DateTime.Now;
            LeasedEndDate = LeasedStartDate.Value.AddMonths(leasemonths);
        }
    }
}
