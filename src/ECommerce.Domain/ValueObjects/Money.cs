using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Money(decimal Amount, string Currency = "VND")
{
    public static Money Zero => new(0);

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new DomainException("Cannot add different currencies");
        return new Money(a.Amount + b.Amount, a.Currency);
    }
}