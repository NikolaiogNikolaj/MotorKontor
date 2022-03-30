using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;

namespace MotorKontor.BL.Service
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        // Her er hvor man indsætter logikken. Det vil sige at hvis man for eksempel skal ændre et navn på en Customer
        // skal det gøres her via at hente user ned. Repositoryen fungere KUN til at sende dataen afsted via metoder du kan access herfra.
        // _repository sørger for at man kan access de metoder.



        //  Method that simulate leasing vehicle
        public async Task<bool> LeaseVehicleToCustomer(int customerid, int vehicleid, int leasingmonths)
        {
            Customer userResponse = new Customer();
            userResponse = await _repository.GetCustomerAsync(customerid);

            var vehicle = await _repository.GetVehicleAsync(vehicleid);

            if (userResponse == null || vehicle == null)
                return false;

            var newRegistration = new Registration(vehicle.CarModel, leasingmonths, vehicle.FuelType, customerid, vehicle.VehicleID);
            vehicle.IsLeased = true;
            userResponse.UserRegistratedVehicles.Add(newRegistration);

            await _repository.UpdateVehicleAsync(vehicle);
            return await _repository.UpdateCustomerAsync(userResponse);
        }




        //  POST METHODS 
        public async Task<bool> PostCustomerAsync(CustomerDTO c)
        {
            var newCustomerModel = new Customer(c.Username, c.Password, c.Firstname, c.Lastname, c.Email, c.PhoneNr, c.Role);
            return await _repository.PostCustomerAsync(newCustomerModel);
        }

        public async Task<bool> PostVehicleAsync(VehicleDTO v)
        {
            var newVehicleModel = new Vehicle(v.CarManufacturer, v.CarModel, v.VehicleRegistrationDate, v.FuelType);
            return await _repository.PostVehicleAsync(newVehicleModel);
        }

        public async Task<bool> PostAddressAsync(AddressDTO a, int customerid)
        {
            var response = await _repository.GetCustomerAsync(customerid);
            var newAddressModel = new Address(a.StreetAddress, a.StreetNumber, a.Town, a.Zipcode);
            response.UserAddress = newAddressModel;
            return await _repository.UpdateCustomerAsync(response);
        }


        //  GET METHODS 
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _repository.GetCustomerAsync(id);
        }

        public async Task<List<Customer>> GetCustomersListAsync()
        {
            return await _repository.GetCustomersListAsync();
        }

        public async Task<Vehicle> GetVehicleAsync(int vehicleid)
        {
            return await _repository.GetVehicleAsync(vehicleid);
        }

        public async Task<List<Vehicle>> GetVehicleListAsync()
        {
            return await _repository.GetVehicleListAsync();
        }

        public async Task<List<Vehicle>> StoredProcedureExampelFuelType(Fuel fueltype)
        {
            return await _repository.StoredProcedureExampelFuelType(fueltype);
        }

        public async Task<List<Customer>> GetCustomersFromCity(string city)
        {
            return await _repository.GetCustomersFromCity(city);
        }
        public async Task<List<Vehicle>> AvailableVehicleToLease()
        {
            return await _repository.AvailableVehicleToLease();
        }


        //  UPDATE METHODS 

        public async Task<bool> UpdateCustomer(CustomerDTO c)
        {
            var newModel = new Customer(Int32.Parse(c.CustomerId), c.Username, c.Password, c.Firstname, c.Lastname, c.Email, c.PhoneNr, c.Role);
            return await _repository.UpdateCustomerAsync(newModel);
        }

        //  REMOVE METHODS 
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var userResponse = await _repository.GetCustomerAsync(id);
            if (userResponse == null)
                return false;

            return await _repository.DeleteCustomerAsync(userResponse);
        }


        public async Task<bool> DeleteVehicleAsync(int vehicleid)
        {
            var vehicleReponse = await _repository.GetVehicleAsync(vehicleid);
            if (vehicleReponse == null)
                return false;

            return await _repository.DeleteVehicleAsync(vehicleReponse);
        }
        public async Task<bool> DeleteCustomerVehicleAsync(int registrationid, int customerid)
        {
            var customerVehicle = await _repository.GetCustomerAsync(customerid);
            if (customerVehicle == null)
                return false;

            var registration = customerVehicle.UserRegistratedVehicles.SingleOrDefault(x => x.RegistrationID == registrationid);

            customerVehicle.UserRegistratedVehicles.Remove(registration);
            return await _repository.UpdateCustomerAsync(customerVehicle);
        }

        ////skal nok laves om
        public async Task<bool> DeleteCustomerAddressAsync(int customerid)
        {
            var customerAddress = await _repository.GetCustomerAsync(customerid);
            if (customerAddress == null)
                return false;

            customerAddress.UserAddress = null;

            return await _repository.DeleteCustomerAsync(customerAddress);

        }


    }
}
