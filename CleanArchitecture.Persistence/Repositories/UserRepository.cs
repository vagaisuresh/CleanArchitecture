using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(i => i.Role)
                .OrderBy(o => o.FullName)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersPagingAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .Include(i => i.Role)
                .OrderBy(o => o.FullName)
                .ToListAsync();
        }

        public async Task<User?> GetUserAsync(short id)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(i => i.Role)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<User?> GetUserByIdAsync(short id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}