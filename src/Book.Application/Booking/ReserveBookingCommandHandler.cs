using Book.Application.Abstraction.Messaging;
using Book.Domain.Abstraction;
using Book.Domain.Apartment.Errors;
using Book.Domain.Apartment.Repository;
using Book.Domain.Booking;
using Book.Domain.Booking.Errors;
using Book.Domain.Booking.Repository;
using Book.Domain.Users.IUserRepository;
using Book.Domain.Users.UserErrors;

namespace Book.Application.Booking
{
    internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;

        public ReserveBookingCommandHandler(IUserRepository userRepository, 
            IApartmentRepository apartmentRepository, IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork, PricingService pricingService)
        {
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
        }
        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null) { return Result.Failure<Guid>(UserErrors.NotFound);}

            var apartment =  await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);   

            if (apartment is null) { return Result.Failure<Guid>(ApartmentErrors.NotFound);}

            var duration =  DateRange.Create(request.StartDate, request.EndDate);   

            if(await _bookingRepository.IsOverlappingAsync(apartment,duration, cancellationToken))
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }

            var booking = Domain.Booking.Booking
                .Reserve(apartment,user.Id,duration,DateTime.Now,_pricingService);

            _bookingRepository.Add(booking);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
    }
}
