namespace TaheriShop.Domain.UnitTests.Helpers;

/// <summary>
/// Provides values used to arrange domain tests without hard-coded identifiers
/// or balances.
/// </summary>
public static class TestHelper
{
    private const int MaximumIdentifier = 1_000_000;
    private const int MaximumBalanceInCents = 1_000_000_00;

    public static int GetSomeAccountId() =>
        Random.Shared.Next(1, MaximumIdentifier);

    public static int GetSomeCustomerId() =>
        Random.Shared.Next(1, MaximumIdentifier);

    public static decimal GetSomeAccountBalance() =>
        Random.Shared.Next(0, MaximumBalanceInCents) / 100m;

    public static decimal GetSomeAmountThatIsEqualOrLessThanZero() =>
        Random.Shared.Next(-MaximumBalanceInCents, 1) / 100m;
}
