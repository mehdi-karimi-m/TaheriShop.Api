using TaheriShop.Framework.Domain.Exceptions;

namespace TaheriShop.Domain.Exceptions;

public sealed class InvalidDepositAmountException(decimal amount) : BusinessException(
    ((int)Exceptions.ErrorCode.InvalidDepositAmount).ToString(),
    $"Deposit amount must be greater than zero. Actual value: {amount}.")
{
    public decimal Amount { get; } = amount;
}