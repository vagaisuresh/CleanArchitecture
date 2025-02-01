namespace CleanArchitecture.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        /// <summary>
        /// SaveAsync is used to commit changes to the database. It wraps the call to SaveChangesAsync on the database context.
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}