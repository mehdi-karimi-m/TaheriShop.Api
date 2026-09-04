using FluentAssertions;
using TaheriShop.Domain.UnitTests.Builders;

namespace TaheriShop.Domain.UnitTests;

public class AccountTests
{
    [Fact]
    public void Create_account()
    {
        var accountId = 1;
        var customerId = 1;

        var account = new AccountBuilder()
            .WithId(accountId)
            .WithCustomerId(customerId)
            .Build();

        account.Should().NotBeNull();
        account.Id.Should().Be(accountId);
        account.CustomerId.Should().Be(customerId);
        account.Balance.Should().Be(0);
    }
}
