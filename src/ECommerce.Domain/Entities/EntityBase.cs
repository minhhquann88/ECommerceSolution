namespace ECommerce.Domain.Entities;

public abstract class EntityBase<TId>
{
    public TId Id { get; protected set; } = default!;

    protected EntityBase() { } // Constructor cho EF Core sau này

    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase<TId> other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Id!.Equals(other.Id);
    }

    public override int GetHashCode() => Id!.GetHashCode();
}