using Microsoft.EntityFrameworkCore;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;

namespace MotorKontor.BL.Repository
{
    public class Repository : IRepository
    {
        private readonly myContext _repository;
        public Repository(myContext repository)
        {
            _repository = repository;
        }


        //  POST METHODS 

        public async Task<bool> PostCustomerAsync(Customer user)
        {
            try
            {
                await _repository.Customer.AddAsync(user);
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
            {
                return false;
            }
        }



        //  GET METHODS 

        //GET CUSTOMER FROM ID
        public async Task<Customer> GetCustomerAsync(int id)
        {
            var response = await _repository.Customer.FirstOrDefaultAsync(x => x.CustomerID == id);
            if (response == null)
                return null;

            return response;
        }

        //GET 5 LATEST USERs CREATED
        public async Task<List<Customer>> GetCustomersListAsync()
        {
            return await _repository.Customer.OrderByDescending(p => p.UserCreation).Take(5).ToListAsync();
        }


        //GET VEHICLE FROM ID
        public async Task<Vehicle> GetVehicleAsync(int vehicleid)
        {
            var response = await _repository.Vehicle.FirstOrDefaultAsync(x => x.VehicleID == vehicleid);
            if (response == null)
                return null;

            return response;
        }

        public async Task<List<Vehicle>> GetVehicleListAsync()
        {
            return await _repository.Vehicle.ToListAsync();
        }


        // GET ALL VEHCICLES BASED ON FUEL TYPE

        public async Task<List<Vehicle>> GetVehiclesByFuelTypeAsync(Fuel type)
        {
            return await _repository.Vehicle.Where(x => x.FuelType == type).ToListAsync();
        }

        public async Task<List<Vehicle>> StoredProcedureExampelFuelType(Fuel fueltype)
        {
            return await _repository.Vehicle.FromSqlRaw<Vehicle>("spGetVehiclesByFuelType {0}", fueltype)
                .ToListAsync();
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
                _repository.Customer.Update(customer);
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
            if(response == null)
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