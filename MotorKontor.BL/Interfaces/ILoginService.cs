using MotorKontor.BL.Models;
using MotorKontor.BL.Models.JWT;

namespace MotorKontor.BL.Interfaces
{
    public interface ILoginService
    {
        //Gets refresh and jwt from user login
        Task<AuthenticateResponse> Authenticate(Customer customer, string ipaddress);

        //Sets active token to not active and gets new refresh and jwt
        Task<AuthenticateResponse> RefreshToken(string token, string ipaddress);

        //Sets active token to not active
        Task<bool> RevokeToken(string token, string ipadress);
        Task<Customer> GetCustomerByID(int id);
    }
}
