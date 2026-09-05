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

        return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TKey> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
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
