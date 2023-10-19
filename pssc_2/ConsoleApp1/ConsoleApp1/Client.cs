using System;

namespace ShoppingCart.Domain
{
    public class Client
    {
        public string Name { get; }

        public Client(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidClientNameException("Client name cannot be empty.");
            Name = name;
        }
    }
}
