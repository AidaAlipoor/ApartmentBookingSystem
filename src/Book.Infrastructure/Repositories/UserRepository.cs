using Book.Domain.Users;
using Book.Domain.Users.IUserRepository;
using Book.Infrastructure.Repositories.BaseRepository;

namespace Book.Infrastructure.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
