using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _service.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPagingAsync([FromQuery] UserParameters userParameters)
        {
            var users = await _service.GetUsersPagingAsync(userParameters);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(short id)
        {
            var user = await _service.GetUserByIdAsync(id);
            return Ok(user);
        }
    }
}