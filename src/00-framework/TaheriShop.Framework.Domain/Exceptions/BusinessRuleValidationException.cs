using TaheriShop.Framework.Domain.Rules;

namespace TaheriShop.Framework.Domain.Exceptions;

public sealed class BusinessRuleValidationException : Exception
{
    public BusinessRuleValidationException(IBusinessRule brokenRule)
        : base(GetMessage(brokenRule))
    {
        BrokenRule = brokenRule;
    }

    public IBusinessRule BrokenRule { get; }

    private static string GetMessage(IBusinessRule brokenRule)
    {
        ArgumentNullException.ThrowIfNull(brokenRule);
        return brokenRule.Message;
    }
}
