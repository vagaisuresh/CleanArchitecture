using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersPagingAsync(int pageNumber, int pageSize);
        Task<User?> GetUserByIdAsync(short id);

        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}