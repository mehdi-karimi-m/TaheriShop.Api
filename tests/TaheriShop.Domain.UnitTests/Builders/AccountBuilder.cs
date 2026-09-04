using TaheriShop.Domain;

namespace TaheriShop.Domain.UnitTests.Builders;

public class AccountBuilder
{
    private int _accountId = 1;
    private int _customerId = 1;

    public AccountBuilder WithId(int accountId)
    {
        _accountId = accountId;
        return this;
    }

    public AccountBuilder WithCustomerId(int customerId)
    {
        _customerId = customerId;
        return this;
    }

    public Account Build()
    {
        return new Account(_accountId, _customerId);
    }
}
