using Book.Domain.Abstraction;

namespace Book.Domain.Booking.Events
{
    public sealed record BookingCancelledDomainEvent(Guid bookId) : IDomainEvent;
}
