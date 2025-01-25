using FluentValidation;

namespace Book.Application.Booking.ReserveBooking
{
    public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            RuleFor(user => user.UserId).NotEmpty();
            RuleFor(a => a.ApartmentId).NotEmpty();
            RuleFor(r => r.StartDate).LessThan(r => r.EndDate);
        }
    }
}
