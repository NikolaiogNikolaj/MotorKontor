using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotorKontor.BL.Models.JWT
{
    public class RefreshToken
    {
        [Key]
        [JsonIgnore] //Næstkommende property bliver ikke vist
        public int Id { get; set; }

        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow > Expires;
        public DateTime Created { get; set; }
        public string? CreatedByIp { get; set; }
        //refreshes
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplaceByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
