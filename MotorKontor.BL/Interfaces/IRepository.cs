using MotorKontor.BL.Models;

namespace MotorKontor.BL.Interfaces
{
    public interface IRepository
    {
        //JWT
        Task<Customer> Login(string username, string password);
        Task<Customer> TokenRefreshRevoke(string token);
        Task<Customer> GetCustomerById (int id);
        Task<bool> UpdateCustomerAsync(Customer customer);
    }
}
    