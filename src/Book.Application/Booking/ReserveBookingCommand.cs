using Book.Application.Abstraction.Messaging;
using Book.Domain.Booking;
using Book.Domain.Shared;
using System.Windows.Input;

namespace Book.Application.Booking
{
    public record ReserveBookingCommand
        (
            Guid ApartmentId,
            Guid UserId,
            DateOnly StartDate,
            DateOnly EndDate
        ) : ICommand<Guid>;
}
