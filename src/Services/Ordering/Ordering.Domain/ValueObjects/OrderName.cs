namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    private const int DefaultLength = 5;
    public string Value { get; } = default!;
    private OrderName(string value) => Value = value;

    public static OrderName Of(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Order name cannot be empty.");
        }

        return new OrderName(value);
    }
}
