using System;

namespace ShoppingCart.Domain
{
    public record CartItem(ProductCode Code, Quantity Quantity);

    public record ProductCode(string Value)
    {
        public ProductCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidProductCodeException("Product code cannot be empty.");
            Value = value;
        }
    }

    public record Quantity(int Value)
    {
        public Quantity(int value)
        {
            if (value <= 0)
                throw new InvalidQuantityException("Quantity must be greater than zero.");
            Value = value;
        }
    }
}
