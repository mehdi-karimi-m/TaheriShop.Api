using TaheriShop.Domain.UnitTests.Helpers;

namespace TaheriShop.Domain.UnitTests.Builders;

public class AccountBuilder
{
    private int _accountId;
    private int _customerId;
    private decimal _balance;

    private AccountBuilder()
    {
        _accountId = TestHelper.GetSomeAccountId();
        _customerId = TestHelper.GetSomeCustomerId();
        _balance = decimal.Zero;
    }

    public static AccountBuilder Create()
    {
        return new AccountBuilder();
    }

    public Account Build()
    {
        return new Account(_accountId, _customerId, _balance);
    }

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

    public AccountBuilder WithBalance(decimal balance)
    {
        _balance = balance;
        return this;
    }
}
