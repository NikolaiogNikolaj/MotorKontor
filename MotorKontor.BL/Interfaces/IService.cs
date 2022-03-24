using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;

namespace MotorKontor.BL.Interfaces
{
    public interface IService
    {

        //ADD Registration to a vehicle
        Task<bool> AddRegistrationToVehicleAsync(RegistrationDTO registration, int id);

        //ADD Vehicles to a customer list for simulating leasing
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
