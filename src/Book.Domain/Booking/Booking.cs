using Book.Domain.Abstraction;
using Book.Domain.Booking.Errors;
using Book.Domain.Booking.Events;
using Book.Domain.Shared;

namespace Book.Domain.Booking
{
    public sealed class Booking : Entity
    {
        public Booking(Guid id, Guid apartmentId, Guid userId, 
            DateRange duration, Money priceForPeriod,
            Money cleaningFee, Money amenitiesUpCharge, 
            Money totalPrice, BookingStatus status, 
            DateTime createdOnUts) : base(id)
        {
            ApartmentId = apartmentId;
            UserId = userId;
            Duration = duration;
            PriceForPeriod = priceForPeriod;
            CleaningFee = cleaningFee;
            AmenitiesUpCharge = amenitiesUpCharge;
            TotalPrice = totalPrice;
            Status = status;
            CreatedOnUts = createdOnUts;
        }

        public Guid ApartmentId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PriceForPeriod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money AmenitiesUpCharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime CreatedOnUts { get; private set; }
        public DateTime? ConfirmedOnUts { get; private set; }
        public DateTime? RejectedOnUts { get; private set; }
        public DateTime? CompletedOnUts { get; private set; }
        public DateTime? CanceledOnUts { get; private set; }


        public static Booking Reserve(Apartment.Apartment apartment, Guid userId , 
            DateRange duration, DateTime utcNow, PricingService pricingService)
        {
            var pricingDetails = pricingService.CalculatePrice(apartment, duration);

            var booking = new Booking
                (
                    Guid.NewGuid(),
                    apartment.Id,
                    userId,
                    duration,
                    pricingDetails.PriceForPeriod,
                    pricingDetails.CleaningFee,
                    pricingDetails.AmenityUpCharge,
                    pricingDetails.TotalPrice,
                    BookingStatus.Reserved,
                    utcNow
                );

            booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

            apartment.LastBookedOnUtc = utcNow;

            return booking;
        }


        public Result Confirm(DateTime utcNow)
        {
            if(Status != BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }

            Status = BookingStatus.Confirmed;  
            ConfirmedOnUts = utcNow;

            RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));

            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotReserved);
            }

            Status = BookingStatus.Rejected;
            ConfirmedOnUts = utcNow;

            RaiseDomainEvent(new BookingRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Compelete(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
            {
                return Result.Failure(BookingErrors.NotConfirmed);
            }

            Status = BookingStatus.Completed;
            ConfirmedOnUts = utcNow;

            RaiseDomainEvent(new BookingCompeletedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
            {
                return Result.Failure(BookingErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.StartDate)
            {
                return Result.Failure(BookingErrors.AlreadyStarted);
            }

            Status = BookingStatus.Canceled;
            ConfirmedOnUts = utcNow;

            RaiseDomainEvent(new BookingCancelledDomainEvent(Id));

            return Result.Success();
        }
    }
}
