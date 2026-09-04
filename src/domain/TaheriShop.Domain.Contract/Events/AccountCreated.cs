using TaheriShop.Framework.Domain.Events;

namespace TaheriShop.Domain.Contract.Events;

public sealed record AccountCreated(long AccountId, long CustomerId) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();

    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
