namespace Book.Domain.Booking.Repository
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(
            Apartment.Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken = default);

        void Insert(Booking booking);
    }
}
