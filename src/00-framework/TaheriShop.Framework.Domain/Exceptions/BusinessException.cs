namespace TaheriShop.Framework.Domain.Exceptions;

public abstract class BusinessException(string errorCode, string message) : Exception(message)
{
    public string ErrorCode { get; private set; } = errorCode;
}
