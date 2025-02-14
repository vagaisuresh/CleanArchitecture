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

        [HttpGet("{id}", Name = "GetRole")]
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

        [HttpPost]
        public async Task<IActionResult> PostAsync(RoleSaveDto roleSaveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid role data.");

            try
            {
                var role = _mapper.Map<Role>(roleSaveDto);
                var savedRole = await _service.CreateAsync(role);

                if (savedRole == null)
                    return NotFound();

                var roleDto = _mapper.Map<Role, RoleDto>(savedRole);

                return CreatedAtRoute("GetRole", new { id = roleDto.Id }, roleDto);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] short id, [FromBody] RoleSaveDto roleSaveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid role data.");

            try
            {
                var role = _mapper.Map<RoleSaveDto, Role>(roleSaveDto);
                await _service.UpdateAsync(id, role);

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
                return BadRequest("Invalid id");

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