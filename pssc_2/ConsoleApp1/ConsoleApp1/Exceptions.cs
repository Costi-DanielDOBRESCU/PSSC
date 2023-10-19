using System;

namespace ShoppingCart.Domain
{
    public class InvalidProductCodeException : Exception
    {
        public InvalidProductCodeException(string message) : base(message) { }
    }

    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }

    public class InvalidClientNameException : Exception
    {
        public InvalidClientNameException(string message) : base(message) { }
    }
}
