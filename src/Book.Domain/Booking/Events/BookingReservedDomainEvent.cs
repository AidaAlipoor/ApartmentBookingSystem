using Book.Domain.Abstraction;

namespace Book.Domain.Booking.Events
{
    public sealed record BookingReservedDomainEvent(Guid bookId) : IDomainEvent;
}
