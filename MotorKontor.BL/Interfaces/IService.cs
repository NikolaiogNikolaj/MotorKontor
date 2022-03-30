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
        Task<bool> PostAddressAsync(AddressDTO address, int customerid);

        //  GET METHODS 
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersListAsync();
        Task<Vehicle> GetVehicleAsync(int vehicleid);
        Task<List<Vehicle>> GetVehicleListAsync();
        Task<List<Vehicle>> StoredProcedureExampelFuelType(Fuel fueltype);
        Task<List<Customer>> GetCustomersFromCity(string city);
        Task<List<Vehicle>> AvailableVehicleToLease();


        //UPDATE
        Task<bool> UpdateCustomer(CustomerDTO customer);


        //REMOVES

        Task<bool> DeleteCustomerVehicleAsync(int id, int customerid);
        Task<bool> DeleteCustomerAddressAsync(int customerid);
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> DeleteVehicleAsync(int vehicleid);
    }
}
