using System;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart.Domain.ShoppingCart();
            var client = new ShoppingCart.Domain.Client("John Doe");

            var item1 = new ShoppingCart.Domain.CartItem(new ShoppingCart.Domain.ProductCode("123"), new ShoppingCart.Domain.Quantity(2));
            var item2 = new ShoppingCart.Domain.CartItem(new ShoppingCart.Domain.ProductCode("456"), new ShoppingCart.Domain.Quantity(1));

            cart.AddItem(item1);
            cart.AddItem(item2);

            Console.WriteLine($"Current cart state: {cart.State.GetType().Name}");

            cart.ValidateCart();
            Console.WriteLine($"Current cart state: {cart.State.GetType().Name}");

            cart.PayCart();
            Console.WriteLine($"Current cart state: {cart.State.GetType().Name}");
        }
    }
}
