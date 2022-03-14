using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using PersonManagement.Web.Models.DTO;
using PersonManagement.Web.Models.Requests;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonManagement.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var r = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

            var result = await _service.GetAllAsync();

            return  Ok(result.Adapt<List<PersonDTO>>());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);

            return Ok(result.Adapt<PersonDTO>());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonRequest request)
        {
            var serviceModel = request.Adapt<PersonServiceModel>();

            var id = await _service.CreatAsync(serviceModel);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutPersonRequest request)
        {
            var serviceModel = request.Adapt<PersonServiceModel>();

            var id = await _service.UpdateAsync(serviceModel);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
