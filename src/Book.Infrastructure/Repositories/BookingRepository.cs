using Book.Domain.Apartment;
using Book.Domain.Booking;
using Book.Domain.Booking.Repository;
using Book.Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Book.Infrastructure.Repositories
{
    internal class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private static readonly BookingStatus[] ActiveBookingStatus =
            {BookingStatus.Confirmed, BookingStatus.Reserved, BookingStatus.Completed};

        private readonly ApplicationDbContext _dbContext;
        public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsOverlappingAsync(Apartment apartment,
            DateRange duration, CancellationToken cancellationToken = default) => await _dbContext.Set<Booking>().AllAsync(
                booking =>
                booking.ApartmentId == apartment.Id &&
                booking.Duration.StartDate <= duration.EndDate &&
                booking.Duration.EndDate >= duration.StartDate &&
                ActiveBookingStatus.Contains(booking.Status),
                cancellationToken
                );
    }
}
