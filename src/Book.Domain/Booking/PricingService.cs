using Book.Domain.Apartment;
using Book.Domain.Shared;

namespace Book.Domain.Booking
{
    public class PricingService
    {
        public PricingDetails CalculatePrice(Apartment.Apartment apartment, DateRange dateRange)
        {
            var currency = apartment.Price.currency;

            var amount =  apartment.Price.amount * dateRange.DaysLenght;

            var priceForPeriod = new Money(amount,currency);

            decimal percentageCharge = 0;

            foreach (var amenity in apartment.Amenities) 
            { 
                switch(amenity)
                {
                    case Amenity.GardenView:
                         percentageCharge = 0.05m; break;
                    case Amenity.MountainView:
                        percentageCharge = 0.05m; break;
                    case Amenity.AirConditioning:
                        percentageCharge = 0.01m; break;
                    case Amenity.Parking:
                        percentageCharge = 0.01m; break;
                }
            
            }

            var amenityUpCharge = Money.Zero(currency);

            if(percentageCharge > 0)
            {
                amenityUpCharge = new Money
                    (
                    priceForPeriod.amount * percentageCharge,currency
                    );
            }

            var totalPrice = priceForPeriod;

            if(apartment.CleaningFee.amount > 0)
            {
                totalPrice += apartment.CleaningFee;
            }

            totalPrice += amenityUpCharge;

            return new PricingDetails
                (
                priceForPeriod, apartment.CleaningFee,amenityUpCharge ,totalPrice
                );
        }
    }
}
