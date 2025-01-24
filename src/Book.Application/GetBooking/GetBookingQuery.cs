using Book.Application.Abstraction.Messaging;

namespace Book.Application.GetBooking
{
    public sealed record GetBookingQuery(Guid bookingId) : IQuery<BookingResponse> { };
}
