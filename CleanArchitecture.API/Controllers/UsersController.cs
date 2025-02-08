using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Parameters;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                var users = await _service.GetUsersAsync();

                if (users == null || !users.Any())
                    return NoContent();

                var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPagingAsync([FromQuery] UserParameters userParameters)
        {
            try
            {
                var users = await _service.GetUsersPagingAsync(userParameters);

                if (users == null || !users.Any())
                    return NoContent();

                var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(short id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Invalid ID provided.");

                var user = await _service.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound();

                var userDto = _mapper.Map<UserDto>(user);

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}