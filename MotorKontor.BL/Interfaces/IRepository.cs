using MotorKontor.BL.Models;

namespace MotorKontor.BL.Interfaces
{
    public interface IRepository
    {
        //  POST METHODS
        Task<bool> PostCustomerAsync(Customer user);
        Task<bool> PostVehicleAsync(Vehicle vehicle);
        Task<bool> PostAddressAsync(Address address);


        //  GET METHODS 
        Task<Customer> GetCustomerById(int id);

        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersListAsync();
        Task<Vehicle> GetVehicleAsync(int vehicleid);
        Task<List<Vehicle>> GetVehicleListAsync();
        Task<List<Vehicle>> GetVehicleByManuAsync();

        Task<List<Vehicle>> GetVehiclesByFuelTypeAsync(Fuel type);
        //Task<List<Customer>> GetCustomerByCityAsync(string city);
        Task<Address> GetAddressAsync(int id);
        Task<List<Registration>> GetCustomerVehicleAsync(int id);



        //  UPDATES
        Task<bool> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> UpdateCustomerAsync(Customer customer);


        //REMOVE
        Task<bool> RemoveVehicleAsync(Vehicle vehicle);
        Task<bool> RemoveCustomerAsync(Customer customer);


        // JWT
        Task<Customer> Login(string username, string password);
        Task<Customer> TokenRefreshRevoke(string token);
    }
}
