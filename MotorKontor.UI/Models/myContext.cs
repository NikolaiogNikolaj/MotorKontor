using Microsoft.EntityFrameworkCore;

namespace MotorKontor.UI.Models
{
    public class myContext : DbContext
    {

        public DbSet<Login> Login { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Address> Address { get; set; }

        public myContext(DbContextOptions options) : base(options) { }

    }
}
