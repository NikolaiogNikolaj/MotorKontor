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
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersListAsync();
        Task<Vehicle> GetVehicleAsync(int vehicleid);
        Task<List<Vehicle>> GetVehicleListAsync();
        Task<List<Vehicle>> StoredProcedureExampelFuelType(Fuel fueltype);
        Task<List<Customer>> GetCustomersFromCity(string city);
        Task<List<Vehicle>> AvailableVehicleToLease();


        //  UPDATES
        Task<bool> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> UpdateCustomerAsync(Customer customer);


        //REMOVE
        Task<bool> DeleteVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerVehicleAsync(Registration registration);


        // JWT
        Task<Customer> Login(string username, string password);
        Task<Customer> TokenRefreshRevoke(string token);
    }
}
