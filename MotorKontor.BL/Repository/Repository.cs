using Microsoft.EntityFrameworkCore;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;

namespace MotorKontor.BL.Repository
{
    public class Repository : IRepository
    {
        private readonly MyContext _repository;
        public Repository(MyContext repository)
        {
            _repository = repository;
        }
        //post
        public async Task<Customer> Login(string username, string password)
        {
            var response = await _repository.Customers.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<Customer> TokenRefreshRevoke(string token)
        {
            var response = await _repository.Customers.SingleOrDefaultAsync(x => x.RefreshToken.Any(y => y.Token == token));
            if (response == null)//dette ha ingen effekt lige nu, men hvis den smider null, så kunne det væe at den ville lave noget andet
            {
                return null;
            }
            return response;
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _repository.Customers.SingleOrDefaultAsync(x => x.CustomerId == id);
        }
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _repository.Customers.Update(customer);
                return (await _repository.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}