namespace Book.Domain.Apartment
{
    public record Address(string Country,
        string State,
        string Zipcode,
        string City,
        string Street);
}
