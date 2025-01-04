using Book.Domain.Abstraction;

namespace Book.Domain.Apartment
{
    public sealed class Apartment : Entity
    {
        public Apartment(Guid id, Name name,
            Discription discription, Address address, Money price, Money cleaningFee,
            DateTime? lastBookedOnUtc, List<Amenity> amenities) : base(id)
        {
            Name = name;
            Discription = discription;
            Address = address;
            Price = price;
            CleaningFee = cleaningFee;
            LastBookedOnUtc = lastBookedOnUtc;
            Amenities = amenities;
        }
        public Name Name { get; private set; }
        public Discription Discription { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; private set; }
        public Money CleaningFee { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenity> Amenities { get; private set; } = new List<Amenity>();

    }
}
