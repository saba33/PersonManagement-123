using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using PersonManagement.Services.Models.User;
using PersonManagement.Web.Models.Requests.Account;
using System.Threading.Tasks;

namespace PersonManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountCreateRequest request)
        {
            var result = await _service.CreateAsync(request.Adapt<UserServiceModel>());

            return Ok(result);
        }
        
        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn(AccountLogInRequest request)
        {
            var token = await _service.AuthenticateAsync(request.Username, request.Password);

            return Ok(token);
        }
    }
}
