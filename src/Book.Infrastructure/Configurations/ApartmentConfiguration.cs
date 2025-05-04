using Book.Domain.Apartment;
using Book.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infrastructure.Configurations
{
    internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(apartment => apartment.Id);
            builder.OwnsOne(apartment => apartment.Address);

            builder.Property(apartment => apartment.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.name , value => new Name(value));

            builder.Property(apartment => apartment.Discription)
                .HasMaxLength(2000)
                .HasConversion(discription => discription.discription , value => new Discription(value));

            builder.OwnsOne(apartment => apartment.Price, priceBuilder =>
            {
                priceBuilder.Property(money => money.currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.ValidateCode(code));
            });

            builder.OwnsOne(apartment => apartment.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.currency)
                    .HasConversion(currency => currency.CurrencyCode, code => Currency.ValidateCode(code));
            });

            builder.ToTable("Apartments");
        }
    }
}
