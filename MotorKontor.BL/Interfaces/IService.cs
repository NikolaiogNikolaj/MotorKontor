using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;

namespace MotorKontor.BL.Interfaces
{
    public interface IService
    {


        //Adds registration to customer list for simulating leasing
        Task<bool> LeaseVehicleToCustomer(int customerid, int vehicleid, int leasingmonths);


        //  POST METHODS

        Task<bool> PostCustomerAsync(CustomerDTO user);
        Task<bool> PostVehicleAsync(VehicleDTO vehicle);
        Task<bool> PostAddressAsync(Address address);



        //  GET METHODS 
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersListAsync();
        Task<Address> GetAddressAsync(int id);
        Task<List<Registration>> GetCustomerVehicleAsync(int id);




        Task<Vehicle> GetVehicleAsync(int vehicleid);
        Task<List<Vehicle>> GetVehicleListAsync();

        //Task<List<Customer>> GetCustomersByCityAsync(string city);
        Task<List<Vehicle>> GetVehiclesByFuelTypeAsync(Fuel fueltype);
    }
}
