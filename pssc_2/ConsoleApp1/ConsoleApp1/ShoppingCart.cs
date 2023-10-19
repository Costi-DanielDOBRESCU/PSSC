using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain
{
    public class ShoppingCart
    {
        public CartState.ICartState State { get; private set; }

        private readonly List<CartItem> items = new List<CartItem>();

        public IReadOnlyCollection<CartItem> Items => items.AsReadOnly();

        public ShoppingCart()
        {
            State = new CartState.EmptyCart();
        }

        public void AddItem(CartItem item)
        {
            if (State is CartState.EmptyCart)
            {
                items.Add(item);
                State = new CartState.UnvalidatedCart(items);
            }
            else if (State is CartState.UnvalidatedCart unvalidatedCart)
            {
                items.Add(item);
                State = new CartState.UnvalidatedCart(items.Concat(unvalidatedCart.Items).ToList());
            }
        }

        public void ValidateCart()
        {
            if (State is CartState.UnvalidatedCart unvalidatedCart)
            {
                State = new CartState.ValidatedCart(unvalidatedCart.Items);
            }
        }

        public void PayCart()
        {
            if (State is CartState.ValidatedCart validatedCart)
            {
                State = new CartState.PaidCart(validatedCart.Items);
            }
        }
    }
}
