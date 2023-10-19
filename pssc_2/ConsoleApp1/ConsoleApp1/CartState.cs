using CSharp.Choices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain
{
    [AsChoice]
    public static partial class CartState
    {
        public interface ICartState { }

        public record EmptyCart : ICartState;

        public record UnvalidatedCart(IReadOnlyCollection<CartItem> Items) : ICartState;

        public record ValidatedCart(IReadOnlyCollection<CartItem> Items) : ICartState;

        public record PaidCart(IReadOnlyCollection<CartItem> Items) : ICartState;
    }
}
