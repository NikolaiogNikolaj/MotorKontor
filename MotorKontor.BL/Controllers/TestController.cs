using Microsoft.AspNetCore.Mvc;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Models.DTO;

namespace MotorKontor.BL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private IHttpContextAccessor _contextAccessor;
        private readonly ILoginService _loginService;
        public TestController(ILoginService loginService, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
             _loginService = loginService;
        }
        [HttpPost("Authenticate/Login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginDTO customer)
        {
            var newCustomer = new Customer(customer.UserName, customer.Password);
            var response = await _loginService.Authenticate(newCustomer, IpAddress());
            if (response == null)
            {
                return new UnauthorizedObjectResult(response);
            }
            return new OkObjectResult(response);
        }
        
        private string IpAddress()
        {
            if (_contextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                return _contextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
            else
                return _contextAccessor.HttpContext?.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
