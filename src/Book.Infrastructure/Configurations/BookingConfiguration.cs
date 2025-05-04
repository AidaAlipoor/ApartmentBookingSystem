using Book.Domain.Apartment;
using Book.Domain.Booking;
using Book.Domain.Shared;
using Book.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infrastructure.Configurations
{
    internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(booking => booking.Id);

            builder.OwnsOne(booking => booking.PriceForPeriod, priceBuilder =>
            {
                priceBuilder.Property(money => money.currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.ValidateCode(code));
            });

            builder.OwnsOne(booking => booking.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.ValidateCode(code));
            });

            builder.OwnsOne(booking => booking.AmenitiesUpCharge, priceBuilder =>
            {
                priceBuilder.Property(money => money.currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.ValidateCode(code));
            });

            builder.OwnsOne(booking => booking.TotalPrice, priceBuilder =>
            {
                priceBuilder.Property(money => money.currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.ValidateCode(code));
            });

            builder.OwnsOne(booking => booking.Duration);

            builder.HasOne<Apartment>()
                .WithMany()
                .HasForeignKey(booking => booking.ApartmentId);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(booking => booking.UserId);
        }
    }
}
