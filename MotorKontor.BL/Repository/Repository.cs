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

        public async Task<bool> PostAddressAsync(Address address)
        {
            try
            {
                await _repository.Address.AddAsync(address);
                return (await _repository.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> PostVehicleAsync(Vehicle vehicle)
        {
            try
            {
                await _repository.Vehicle.AddAsync(vehicle);
                return (await _repository.SaveChangesAsync()) > 0; ;
            }
            catch (Exception e)
        public async Task<Customer> TokenRefreshRevoke(string token)
        {
            var response = await _repository.Customers.SingleOrDefaultAsync(x => x.RefreshToken.Any(y => y.Token == token));
            if (response == null)//dette ha ingen effekt lige nu, men hvis den smider null, så kunne det væe at den ville lave noget andet
            {
                return null;

            return response;
        }

        //GET 5 LATEST USERs CREATED
        public async Task<List<Customer>> GetCustomersListAsync()
        {
            return await _repository.Customer.OrderByDescending(p => p.UserCreation).Take(5).ToListAsync();
        }

        public async Task<List<Vehicle>> GetVehicleByManuAsync()
        {
            return await _repository.Vehicle.OrderByDescending(p => p.CarManufacturer).ToListAsync();
        }

        //GET VEHICLE FROM ID
        public async Task<Vehicle> GetVehicleAsync(int vehicleid)
        {
            var response = await _repository.Vehicle.FirstOrDefaultAsync(x => x.VehicleID == vehicleid);
            if (response == null)
                return null;

            }
            return response;
        }



        public async Task<List<Vehicle>> GetVehicleListAsync()
        {
            return await _repository.Vehicle.ToListAsync();
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            var response = await _repository.Address.FirstOrDefaultAsync(x => x.CustomerID == id); //returnerer på customerID
            if (response == null)
                return null;

            return response;
        }
        // GET LIST ALL VEHICLES FROM CUSTOMER //eventuelt en DTO, så man ikke displayer customerID da det er redudant

        public async Task<List<Registration>> GetCustomerVehicleAsync(int id)
        {
            return await _repository.Registration.Where(x => x.CustomerID == id).ToListAsync();
        }

        // GET ALL VEHICLES BASED ON FUEL TYPE

        public async Task<List<Vehicle>> GetVehiclesByFuelTypeAsync(Fuel type)
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _repository.Vehicle.Where(x => x.FuelType == type).ToListAsync();
        }



        //GET ALL CUSTOMERS BASED ON CITY

        //public async Task<List<Customer>> GetCustomerByCityAsync(string city)
        //{
        //    return await _repository.Customer.Where(x => x.UserAddress.Town == city).ToListAsync();
        //}







        //  UPDATE METHODS 

        public async Task<bool> UpdateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                _repository.Vehicle.Update(vehicle);
                return (await _repository.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
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



        //  REMOVE METHODS 

        public async Task<bool> RemoveVehicleAsync(Vehicle vehicle)
        {
            try
            {
                _repository.Vehicle.Remove(vehicle);
                return (await _repository.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveCustomerAsync(Customer customer)
        {
            try
            {
                _repository.Customer.Remove(customer);
                return (await _repository.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Customer> Login(string username, string password)
        {
            var response = await _repository.Customer.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            if (response == null)
                return null;

            return response;
        }

        public async Task<Customer> TokenRefreshRevoke(string token)
        {
            var response = await _repository.Customer.SingleOrDefaultAsync(x => x.RefreshToken.Any(y => y.Token == token));
            if (response == null)
                return null;

            return response;
        }
    }
}