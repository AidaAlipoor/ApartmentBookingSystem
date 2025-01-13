using Book.Domain.Shared;

namespace Book.Domain.Booking
{
    public record PricingDetails
         (
            Money PriceForPeriod,
            Money CleaningFee,
            Money AmenityUpCharge,
            Money TotalPrice
        );
}
