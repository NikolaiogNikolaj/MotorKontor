using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MotorKontor.BL.Models
{
    public class Address
    {
        public Address() { }

        [Key]
        public int? AddressID { get; set; }
        public string? StreetAddress { get; set; }
        public string? StreetNumber { get; set; }
        public string? Town { get; set; }
        public string? Zipcode { get; set; }

        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        public Address(string streetAddress, string streetNumber, string town, string zipcode, int? customerID)
        {
            StreetAddress = streetAddress;
            StreetNumber = streetNumber;
            Town = town;
            Zipcode = zipcode;
            CustomerID = customerID;
        }
    }
}
