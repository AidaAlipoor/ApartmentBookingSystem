using Book.Application.Abstraction.Messaging;

namespace Book.Application.Apartment
{
    internal sealed record SearchApartmentsQuery(DateOnly startDate, DateOnly endDate)
        : IQuery<IReadOnlyList<ApartmentResponse>>{ };
}
