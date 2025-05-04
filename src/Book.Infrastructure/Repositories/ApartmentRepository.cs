using Book.Domain.Apartment;
using Book.Domain.Apartment.Repository;
using Book.Infrastructure.Repositories.BaseRepository;

namespace Book.Infrastructure.Repositories
{
    internal class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
