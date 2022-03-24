﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;
using MotorKontor.BL.Models.JWT;

namespace MotorKontor.BL.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost("Authenticate/Login")]
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





        private string ipAddress()
        {
            if (_contextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                return _contextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
            else
                return _contextAccessor.HttpContext?.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }














        [HttpPost("Add Registration")]
        public async Task<ActionResult<bool>> AddRegistrationToVehicle(RegistrationDTO registration, int vehicleid)
        {
            var response = await _service.AddRegistrationToVehicleAsync(registration, vehicleid);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpPost("Add Customer")]
        public async Task<ActionResult<bool>> AddCustomerToVehicle(int customerid, int vehicleid)
        {
            var response = await _service.AddCustomerToVehicleAsync(customerid, vehicleid);
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

        [HttpPost("Post Customer")]
        public async Task<ActionResult<bool>> PostCustomerAsync(CustomerDTO customer)
        {
            var response = await _service.PostCustomerAsync(customer);
            if (response == false)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpGet("GetCustomersAsync")]
        public async Task<ActionResult<List<Customer>>> GetCustomersAsync()
        {
            var response = await _service.GetCustomersListAsync();
            if (response == null)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }

        [HttpGet("GetVehicle")]
        public async Task<ActionResult<List<Vehicle>>> GetVehicleAsync()
        {
            var response = await _service.GetVehicleListAsync();
            if (response == null)
                return new NotFoundObjectResult(response);

            return new OkObjectResult(response);
        }
    }
}