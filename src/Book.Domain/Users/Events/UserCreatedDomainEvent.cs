using Book.Domain.Abstraction;

namespace Book.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid id) : IDomainEvent
    {
    }
}
