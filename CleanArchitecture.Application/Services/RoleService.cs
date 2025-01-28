using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _repository.GetRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(short id)
        {
            return await _repository.GetRoleByIdAsync(id);
        }
    }
}