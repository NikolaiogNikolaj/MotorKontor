namespace MotorKontor.UI.Models.JWT
{
    public class AuthenticateResponse
    {
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }

        public AuthenticateResponse(int id, string firstname, string lastname, string jwt, string refreshtoken)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            JwtToken = jwt;
            RefreshToken = refreshtoken;
        }
    }
}
