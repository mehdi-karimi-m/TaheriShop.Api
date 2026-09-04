using System.Runtime.CompilerServices;
using TaheriShop.Framework.Domain.Exceptions;
using TaheriShop.Framework.Domain.Rules;

namespace TaheriShop.Framework.Domain.Common;

public abstract class Entity<TKey> : IEntity<TKey>, IEquatable<Entity<TKey>>
    where TKey : notnull
{
    protected Entity()
    {
        Id = default!;
    }

    protected Entity(TKey id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }

    public TKey Id { get; protected set; }

    public bool IsTransient()
    {
        return EqualityComparer<TKey>.Default.Equals(Id, default);
    }

    protected static void CheckRule(IBusinessRule rule)
    {
        ArgumentNullException.ThrowIfNull(rule);

        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    public bool Equals(Entity<TKey>? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other is null || GetType() != other.GetType())
        {
            return false;
        }

        if (IsTransient() || other.IsTransient())
        {
            return false;
        }

        return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TKey> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return IsTransient()
            ? RuntimeHelpers.GetHashCode(this)
            : HashCode.Combine(GetType(), Id);
    }

    public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
    {
        return !(left == right);
    }
}
