using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        public RoleRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(short id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public void Update(Role role)
        {
            _context.Roles.Update(role);
        }

        public void Remove(Role role)
        {
            _context.Roles.Remove(role);
        }
    }
}