namespace TaheriShop.Framework.Domain.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject? other)
    {
        return other is not null
               && GetType() == other.GetType()
               && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && Equals(other);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var component in GetEqualityComponents())
        {
            hashCode.Add(component);
        }

        return hashCode.ToHashCode();
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }
}
