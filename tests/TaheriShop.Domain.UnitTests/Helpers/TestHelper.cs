namespace TaheriShop.Domain.UnitTests.Helpers;

/// <summary>
/// Provides values used to arrange domain tests without hard-coded identifiers
/// or balances.
/// </summary>
public static class TestHelper
{
    private const int MaximumIdentifier = 1_000_000;
    private const int MaximumBalanceInCents = 1_000_000_00;

    public static int CreateRandomAccountId() =>
        Random.Shared.Next(1, MaximumIdentifier);

    public static int CreateRandomCustomerId() =>
        Random.Shared.Next(1, MaximumIdentifier);

    public static decimal CreateRandomAccountBalance() =>
        Random.Shared.Next(0, MaximumBalanceInCents) / 100m;
}
