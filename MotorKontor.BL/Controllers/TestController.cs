using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;
using MotorKontor.BL.Models.JWT;

namespace MotorKontor.BL.Controllers
{
    //[Authorize]
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

            if (response == null)
                return new UnauthorizedObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpPost("Refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RevokeTokenRequest model)
        {
            var response = await _loginService.RefreshToken(model.Token, ipAddress());

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
        [HttpPost("Add-Address")]
        public async Task<ActionResult<bool>> PostAddressAsync(Address address)
        {
            var response = await _service.PostAddressAsync(address);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }
        [HttpPost("Add-Customer")]
        public async Task<ActionResult> LeaseVehicleToCustomer(int customerid, int vehicleid, int leasingmonths)
        {
            var response = await _service.LeaseVehicleToCustomer(customerid, vehicleid, leasingmonths);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpPost("Post vehicle")]
        public async Task<ActionResult<bool>> PostVehicleAsync(VehicleDTO vehicle)
        {
            var response = await _service.PostVehicleAsync(vehicle);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [AllowAnonymous]
        [HttpPost("Post Customer")]
        public async Task<ActionResult<bool>> PostCustomerAsync(CustomerDTO customer)
        {
            var response = await _service.PostCustomerAsync(customer);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }
        //GET


        [HttpGet("GetAllCustomersAsync"), Authorize(Roles = "Admin")]
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

        [HttpGet("Get-Customer")]
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _service.GetCustomerAsync(id);
        }
        [HttpGet("Get-Customer Address")]
        public async Task<Address> GetAddressAsync(int id)
        {
            return await _service.GetAddressAsync(id);
        }


        [HttpGet("Get-Customer Vehicles")]
        public async Task<ActionResult<List<Registration>>> GetCustomerVehicleAsync(int id)
        {
            return await _service.GetCustomerVehicleAsync(id);
        }
        //DELETE
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
