namespace MotorKontor.BL.Models.JWT
{
    public class AuthenticateResponse
    {
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }

        public AuthenticateResponse(Customer customer, string jwt, string refreshtoken)
        {
            Id = customer.CustomerID;
            Firstname = customer.Firstname;
            Lastname = customer.Lastname;
            JwtToken = jwt;
            RefreshToken = refreshtoken;
        }
    }
}
