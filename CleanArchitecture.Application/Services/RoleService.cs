using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _unitOfWork.RoleRepository.GetRolesAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(short id)
        {
            return await _unitOfWork.RoleRepository.GetRoleByIdAsync(id);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            try
            {
                await _unitOfWork.RoleRepository.AddAsync(role);
                await _unitOfWork.SaveAsync();

                return role;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when saving the role: {ex.Message}");
            }
        }

        public async Task UpdateAsync(short id, Role role)
        {
            var existingRole = await _unitOfWork.RoleRepository.GetRoleByIdAsync(id);

            if (existingRole == null)
                throw new InvalidOperationException("Role not found.");

            existingRole.RoleName = role.RoleName;
            existingRole.Description = role.Description;
            existingRole.IsActive = role.IsActive;

            try
            {
                _unitOfWork.RoleRepository.Update(existingRole);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when updating the role: {ex.Message}");
            }
        }

        public async Task DeleteAsync(short id)
        {
            var existingRole = await _unitOfWork.RoleRepository.GetRoleByIdAsync(id);

            if (existingRole == null)
                throw new InvalidOperationException("Category not found.");

            try
            {
                _unitOfWork.RoleRepository.Remove(existingRole);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when saving the role: {ex.Message}");
            }
        }
    }
}