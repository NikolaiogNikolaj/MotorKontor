using System.ComponentModel.DataAnnotations;

namespace MotorKontor.BL.Models
{
    public class CityZipCode {

        public  CityZipCode() { }
        [Key]
        public int CityZipCodeId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }



    }

}
