﻿using AutoMapper;
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
        private readonly ILoggerService _logger;

        public RolesController(IRoleService service, IMapper mapper, ILoggerService logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError($"An error occurred while getting roles in GetRolesAsync method: {ex}");
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

                var role = await _service.GetRoleAsync(id);

                if (role == null)
                    return NotFound();

                var roleDto = _mapper.Map<RoleDto>(role);

                return Ok(roleDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting role in GetRoleAsync method: {ex}");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RoleSaveDto roleSaveDto)
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
                _logger.LogError($"An error occurred while saving role in PostAsync method: {ex}");
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
                _logger.LogError($"An error occurred while updating role in PutAsync method: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] short id)
        {
            if (id == 0)
                return BadRequest("Invalid role id.");

            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting role in DeleteAsync method: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}