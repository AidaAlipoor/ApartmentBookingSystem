using Book.Domain.Abstraction;

namespace Book.Domain.Booking.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid bookId) : IDomainEvent;
}
