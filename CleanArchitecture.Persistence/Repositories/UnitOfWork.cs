using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context,
            IRoleRepository roleRepository,
            IUserRepository userRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public IRoleRepository RoleRepository => _roleRepository;
        public IUserRepository UserRepository => _userRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Dispose of the resources
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}