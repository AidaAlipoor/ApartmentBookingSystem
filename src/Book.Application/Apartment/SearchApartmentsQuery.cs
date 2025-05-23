using Book.Application.Abstraction.Messaging;

namespace Book.Application.Apartment
{
    public sealed record SearchApartmentsQuery(DateOnly startDate, DateOnly endDate)
        : IQuery<IReadOnlyList<ApartmentResponse>>
    { };
}
