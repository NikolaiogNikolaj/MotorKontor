using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;
using MotorKontor.BL.Models.JWT;

namespace MotorKontor.BL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IService _service;



        private IHttpContextAccessor _contextAccessor;
        private readonly ILoginService _loginService;
        public TestController(ILoginService loginService, IHttpContextAccessor contextAccessor, IService service)
        {
            _loginService = loginService;
            _contextAccessor = contextAccessor;


            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginDTO c)
        {
            var newCustomer = new Customer(c.Username, c.Password);

            var response = await _loginService.Authenticate(newCustomer, ipAddress());

            if(response == null)
                return new UnauthorizedObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpPost("Refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RevokeTokenRequest model)
        {
            var response = await _loginService.RefreshToken(model.Token, ipAddress());

            if(response==null)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpPost("Revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            var response = await _loginService.RevokeToken(model.Token, ipAddress());

            if (response == null)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }





        private string ipAddress()
        {
            if (_contextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                return _contextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
            else
                return _contextAccessor.HttpContext?.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }












        //POST
        [HttpPost("AddAddress")]
        public async Task<ActionResult<bool>> PostAddressAsync(AddressDTO address, int customerid)
        {
            var response = await _service.PostAddressAsync(address, customerid);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }


        [HttpPost("AddCustomer")]
        public async Task<ActionResult> LeaseVehicleToCustomer(int customerid, int vehicleid, int leasingmonths)
        {
            var response = await _service.LeaseVehicleToCustomer(customerid, vehicleid, leasingmonths);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpPost("PostVehicle")]
        public async Task<ActionResult<bool>> PostVehicleAsync(VehicleDTO vehicle)
        {
            var response = await _service.PostVehicleAsync(vehicle);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [AllowAnonymous]
        [HttpPost("PostCustomer")]
        public async Task<ActionResult<bool>> PostCustomerAsync(CustomerDTO customer)
        {
            var response = await _service.PostCustomerAsync(customer);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        
        [HttpGet("GetCustomersAsync"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Customer>>> GetCustomersAsync()
        {
            var response = await _service.GetCustomersListAsync();
            if (response == null)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpGet("GetVehicles")]
        public async Task<ActionResult<List<Vehicle>>> GetVehicleAsync()
        {
            var response = await _service.GetVehicleListAsync();
            if (response == null)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpGet("GetCustomer")]
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _service.GetCustomerAsync(id);
        }

        [HttpGet("GetFueltype")]
        public async Task<ActionResult<List<Vehicle>>> StoredProcedureExampelFuelType(Fuel fueltype)
        {
            return await _service.StoredProcedureExampelFuelType(fueltype);
        }

        [HttpGet("GetAvailableVehicles")]
        public async Task<ActionResult<List<Vehicle>>> AvailableVehicleToLease()
        {
            return await _service.AvailableVehicleToLease();
        }
        
        [HttpGet("GetCustomersByCity")]
        public async Task<ActionResult<List<Customer>>> GetCustomersFromCity(string city)
        {
            return await _service.GetCustomersFromCity(city);
        }




        [HttpPost("Updatetest")]
        public async Task<ActionResult<bool>> UpdateCustomer([FromBody] CustomerDTO customer)
        {
            return await _service.UpdateCustomer(customer);
        }


        [HttpDelete("Delete-Customer")]
        //[Authorize(Roles = "Superadmin")]
        public async Task<ActionResult<bool>> DeleteCustomerAsync(int id)
        {
            return await _service.DeleteCustomerAsync(id);
        }
        [HttpDelete("Delete-Vehicle")]
        //[Authorize(Roles = "Superadmin")]
        public async Task<ActionResult<bool>> DeleteVehicleAsync(int id)
        {
            return await _service.DeleteVehicleAsync(id);
        }

        [HttpDelete("Delete-Customer Vehicle")]
        //[Authorize(Roles = "Superadmin")]
        public async Task<ActionResult<bool>> DeleteCustomerVehicleAsync(int registrationId, int customerId)
        {
            return await _service.DeleteCustomerVehicleAsync(registrationId, customerId);
        }

        [HttpDelete("Delete-Customer Address")]
        //[Authorize(Roles = "Superadmin")]
        public async Task<ActionResult<bool>> DeleteCustomerAddressAsync(int customerId)
        {
            return await _service.DeleteCustomerAddressAsync(customerId);
        }

    }
}
