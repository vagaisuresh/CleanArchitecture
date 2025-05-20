using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRoleAsync(short id);
        Task<Role?> GetRoleByIdAsync(short id);

        Task AddAsync(Role role);
        void Update(Role role);
        void Remove(Role role);
    }
}