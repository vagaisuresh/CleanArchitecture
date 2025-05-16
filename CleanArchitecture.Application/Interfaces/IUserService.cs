using CleanArchitecture.Application.Parameters;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersPagingAsync(UserParameters parameters);
        Task<User?> GetUserAsync(short id);

        Task<User> CreateAsync(User user);
        Task UpdateAsync(short id, User user);
        Task DeleteAsync(short id);
    }
}