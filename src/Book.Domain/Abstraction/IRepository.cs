namespace Book.Infrastructure.Repositories.BaseRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
