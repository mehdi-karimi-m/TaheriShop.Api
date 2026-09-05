using FluentAssertions;
using TaheriShop.Domain.Contract.Events;
using TaheriShop.Domain.Exceptions;
using TaheriShop.Domain.UnitTests.Builders;
using TaheriShop.Domain.UnitTests.Helpers;

namespace TaheriShop.Domain.UnitTests;

public class AccountTests
{
    [Fact]
    public void Create_account()
    {
        var accountId = TestHelper.GetSomeAccountId();
        var customerId = TestHelper.GetSomeCustomerId();

        var account = AccountBuilder.Create()
            .WithId(accountId)
            .WithCustomerId(customerId)
            .Build();

        account.Should().NotBeNull();
        account.Id.Should().Be(accountId);
        account.CustomerId.Should().Be(customerId);
        account.Balance.Should().Be(0);
        account.DomainEvents.Should().ContainSingle()
            .Which.Should().BeOfType<AccountCreated>();
    }

    [Fact]
    public void Increase_balance_when_deposit()
    {
        var account = AccountBuilder.Create()
            .WithBalance(100_000)
            .Build();
        const decimal depositAmount = 200_000;

        account.Deposit(depositAmount);

        account.Balance.Should().Be(300_000);
    }

    [Fact]
    public void Does_not_increase_balance_when_deposit_amount_is_equal_or_less_than_zero()
    {
        var depositAmount = TestHelper.GetSomeAmountThatIsEqualOrLessThanZero();
        var account = AccountBuilder.Create().Build();

        var depositAction = () => account.Deposit(depositAmount);

        depositAction.Should().Throw<InvalidDepositAmountException>();
    }
}
