class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
    DatabaseHelper dbHelper = new DatabaseHelper(connectionString);

        Console.WriteLine("Introduceti datele pentru tabela Product:");
        Console.Write("ProductId: ");
        int productId = int.Parse(Console.ReadLine());
        Console.Write("Code: ");
        string code = Console.ReadLine();
        Console.Write("Stoc: ");
        int stoc = int.Parse(Console.ReadLine());
        dbHelper.InsertProduct(productId, code, stoc);

        Console.WriteLine("Introduceti datele pentru tabela OrderHeader:");
        Console.Write("OrderId: ");
        int orderId = int.Parse(Console.ReadLine());
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("Total: ");
        decimal total = decimal.Parse(Console.ReadLine());
        dbHelper.InsertOrderHeader(orderId, address, total);

        Console.WriteLine("Introduceti datele pentru tabela OrderLine:");
        Console.Write("OrderLineId: ");
        int orderLineId = int.Parse(Console.ReadLine());
        Console.Write("ProductId: ");
        int orderLineProductId = int.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine());
        dbHelper.InsertOrderLine(orderLineId, orderLineProductId, quantity, price);

        Console.WriteLine("Datele au fost introduse cu succes în baza de date.");
        Console.ReadLine();
    }
}
