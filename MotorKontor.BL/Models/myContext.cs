using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace MotorKontor.BL.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CityZipCode> CityZipCodes { get; set; }
        public MyContext (DbContextOptions options) : base (options) { } //ctor
    }
}
