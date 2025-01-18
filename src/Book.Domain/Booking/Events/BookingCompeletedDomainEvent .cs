using Book.Domain.Abstraction;

namespace Book.Domain.Booking.Events
{
    public sealed record BookingCompeletedDomainEvent(Guid bookId) : IDomainEvent;
}
