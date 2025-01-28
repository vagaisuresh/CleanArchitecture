using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetRoleByIdAsync(short id);
    }
}