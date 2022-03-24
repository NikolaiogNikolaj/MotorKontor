using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;

namespace MotorKontor.BL.Interfaces
{
    public interface IService
    {

        //   ADMIN INTERFACE METHODS
        //   POST == admin user need to confirm deal
        Task<bool> AddRegistrationToVehicleAsync(RegistrationDTO registration, int id);
        Task<bool> AddCustomerToVehicleAsync(int customerid, int vehicleid);




        //  POST METHODS
        Task<bool> PostCustomerAsync(CustomerDTO user);
        Task<bool> PostVehicleAsync(VehicleDTO vehicle);

        //  GET METHODS 
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersListAsync();
        Task<Vehicle> GetVehicleAsync(int vehicleid);
        Task<List<Vehicle>> GetVehicleListAsync();
        //Task<List<Customer>> GetCustomersByCityAsync(string city);
        Task<List<Vehicle>> GetVehiclesByFuelTypeAsync(Fuel fueltype);
    }
}
