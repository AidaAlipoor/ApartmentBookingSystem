namespace Book.Domain.Users.IUserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Insert(User user);
    }
}
