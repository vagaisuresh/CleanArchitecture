using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
    }
}