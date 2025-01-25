using Book.Application.Abstraction.Messaging;

namespace Book.Application.Booking.ReserveBooking
{
    public record ReserveBookingCommand
        (
            Guid ApartmentId,
            Guid UserId,
            DateOnly StartDate,
            DateOnly EndDate
        ) : ICommand<Guid>;
}
