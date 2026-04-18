using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public static Category Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Category name cannot be empty");

        return new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };
    }

    private Category() { }
}