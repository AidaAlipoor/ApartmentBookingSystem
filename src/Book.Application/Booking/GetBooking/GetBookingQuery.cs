using Book.Application.Abstraction.Messaging;

namespace Book.Application.Booking.GetBooking
{
    public sealed record GetBookingQuery(Guid bookingId) : IQuery<BookingResponse> { };
}
