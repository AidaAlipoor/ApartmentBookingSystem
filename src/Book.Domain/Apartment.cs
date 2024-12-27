using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain
{
    public sealed class Apartment
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Discription { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public decimal PriceAmount { get; private set; }
        public string PriceCurrency { get; private set; }
        public decimal CleaningFeeAmount { get; private set; }
        public string CleaningFeeCurrency { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }

        public List<Amenity> Amenities { get; private set;} = new List<Amenity>();  

    }
}
