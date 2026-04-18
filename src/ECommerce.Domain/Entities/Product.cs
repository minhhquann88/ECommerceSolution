using ECommerce.Domain.ValueObjects;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.Entities;

public class Product : EntityBase<Guid>
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Money Price { get; private set; } = Money.Zero;
    public int StockQuantity { get; private set; }
    public Guid CategoryId { get; private set; }

    // Factory Method – cách tạo Entity chuẩn DDD
    public static Product Create(string name, string description, Money price, int stockQuantity, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Product name cannot be empty");

        if (price.Amount <= 0)
            throw new DomainException("Product price must be greater than zero");

        if (stockQuantity < 0)
            throw new DomainException("Stock quantity cannot be negative");

        return new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = stockQuantity,
            CategoryId = categoryId
        };
    }

    // Business method
    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("Quantity to decrease must be positive");

        if (StockQuantity < quantity)
            throw new DomainException("Not enough stock");

        StockQuantity -= quantity;
    }

    // Constructor private cho EF Core
    private Product() { }
}