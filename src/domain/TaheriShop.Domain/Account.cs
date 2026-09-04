using TaheriShop.Framework.Domain.Common;
using TaheriShop.Domain.Contract.Events;

namespace TaheriShop.Domain;

public class Account : AggregateRoot<long>
{
    public long CustomerId { get; private set; }
    public decimal Balance { get; private set; }

    public Account(int accountId, int customerId)
        : base(accountId)
    {
        CustomerId = customerId;
        AddDomainEvent(new AccountCreated(Id, CustomerId));
    }
}
