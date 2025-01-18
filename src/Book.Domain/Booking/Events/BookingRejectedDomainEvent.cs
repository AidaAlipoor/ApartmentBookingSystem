using Book.Domain.Abstraction;

namespace Book.Domain.Booking.Events
{
    public sealed record BookingRejectedDomainEvent(Guid bookId) : IDomainEvent;
}
