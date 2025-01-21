using Book.Application.Abstraction.Email;
using Book.Domain.Apartment.Repository;
using Book.Domain.Booking.Events;
using Book.Domain.Booking.Repository;
using Book.Domain.Users.IUserRepository;
using MediatR;

namespace Book.Application.Booking
{
    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingRejectedDomainEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(IUserRepository userRepository, 
            IBookingRepository bookingRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingRejectedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.bookId,cancellationToken);

            if (booking is null) { return; }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

            if (user is null) { return; }

            await _emailService.SendAsync(user.Email,
                "Booking is reserved!", "you have 10 minutes to confirm this booking.");
        }
    }
}
