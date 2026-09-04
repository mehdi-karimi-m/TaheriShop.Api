using System.Collections.ObjectModel;
using TaheriShop.Framework.Domain.Events;

namespace TaheriShop.Framework.Domain.Common;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    where TKey : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];
    private ReadOnlyCollection<IDomainEvent>? _domainEventsView;

    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TKey id)
        : base(id)
    {
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEventsView ??= _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
