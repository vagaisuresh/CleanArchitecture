using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public RolesController(IRoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRolesAsync()
        {
            try
            {
                var roles = await _service.GetAllRolesAsync();

                if (roles == null || !roles.Any())
                    return NoContent();

                var roleDtos = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles);

                return Ok(roleDtos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleAsync(short id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Invalid ID provided.");

                var role = await _service.GetRoleByIdAsync(id);

                if (role == null)
                    return NotFound();

                var roleDto = _mapper.Map<RoleDto>(role);

                return Ok(roleDto);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}