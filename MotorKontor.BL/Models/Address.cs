using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorKontor.BL.Models
{
    public class Address
    {
        public Address() { }
        [Key]
        public int AddressId { get; set; }        
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        //foreign key
        [ForeignKey("CityZipCodeId")]
        public int CityZipCodeId { get; set; }

         //Navigational properties
       
        public CityZipCode CityZipCode { get; set; } // 1-1, 1 CityZipCode per Address
        

        public Address(string streetNumber, string streetName) {
            streetNumber = streetNumber;
            streetName = streetName;
        }

    }
}
