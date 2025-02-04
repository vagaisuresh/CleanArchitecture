using CleanArchitecture.Application.Parameters;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersPagingAsync(UserParameters parameters);
        Task<User> GetUserByIdAsync(short id);
    }
}