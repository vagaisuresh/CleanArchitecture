using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(short id);

        Task<Role> CreateAsync(Role role);
        Task UpdateAsync(short id, Role role);
        Task DeleteAsync(short id);
    }
}