using TaheriShop.Framework.Domain.Common;
using TaheriShop.Domain.Contract.Events;
using TaheriShop.Domain.Exceptions;

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

    public Account(int accountId, int customerId, decimal balance)
        : this(accountId, customerId)
    {
        Balance = balance;
    }

    public void Deposit(decimal depositAmount)
    {
        MakeSureAmountIsGreaterThatZero(depositAmount);

        Balance += depositAmount;
    }

    private static void MakeSureAmountIsGreaterThatZero(decimal amount)
    {
        if (amount <= decimal.Zero)
        {
            throw new InvalidDepositAmountException(amount);
        }
    }
}
