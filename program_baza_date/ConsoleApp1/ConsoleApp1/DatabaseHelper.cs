using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void InsertProduct(int productId, string code, int stoc)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Product (ProductId, Code, Stoc) VALUES (@ProductId, @Code, @Stoc)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@Stoc", stoc);
                command.ExecuteNonQuery();
            }
        }
    }

    public void InsertOrderHeader(int orderId, string address, decimal total)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO OrderHeader (OrderId, Address, Total) VALUES (@OrderId, @Address, @Total)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Total", total);
                command.ExecuteNonQuery();
            }
        }
    }

    public void InsertOrderLine(int orderLineId, int productId, int quantity, decimal price)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO OrderLine (OrderLineId, ProductId, Quantity, Price) VALUES (@OrderLineId, @ProductId, @Quantity, @Price)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderLineId", orderLineId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Price", price);
                command.ExecuteNonQuery();
            }
        }
    }
}
