namespace Book.Infrastructure.Repositories.BaseRepository
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public void Insert(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

    }
}
