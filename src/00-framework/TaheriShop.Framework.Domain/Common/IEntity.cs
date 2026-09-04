namespace TaheriShop.Framework.Domain.Common;

public interface IEntity<TKey>
    where TKey : notnull
{
    TKey Id { get; }
}
