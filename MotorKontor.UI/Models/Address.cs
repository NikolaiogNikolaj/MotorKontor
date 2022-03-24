using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.UI.Models
{
    public class Address
    {
        public Address() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AddressID { get; set; }
        public string? StreetAddress { get; set; }
        public string? StreetNumber { get; set; }
        public string? Town { get; set; }
        public string? Zipcode { get; set; }
    }
}
