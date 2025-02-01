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
            var users =  await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(short id)
        {
            return await _context.Users.FindAsync(id) ?? new User();
        }
    }
}