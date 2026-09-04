using FluentAssertions;
using TaheriShop.Domain.Events;
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

        var account = new AccountBuilder()
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
}
