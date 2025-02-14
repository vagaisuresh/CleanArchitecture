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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserSaveDto userSaveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid role data.");

            try
            {
                var user = _mapper.Map<UserSaveDto, User>(userSaveDto);
                var savedUser = await _service.CreateAsync(user);

                if (savedUser == null)
                    return NotFound();

                var userDto = _mapper.Map<User, UserDto>(savedUser);
                return CreatedAtRoute("GetUser", new { id = userDto.Id }, userDto);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] short id, [FromBody] UserSaveDto userSaveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid user data.");

            try
            {
                var user = _mapper.Map<UserSaveDto, User>(userSaveDto);
                await _service.UpdateAsync(id, user);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] short id)
        {
            if (id == 0)
                return BadRequest("Invalid user id.");

            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}