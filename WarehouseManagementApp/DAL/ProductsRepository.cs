using Npgsql;
using System.Collections.Generic;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;

public class ProductsRepository
{
   
    private readonly string _connectionString;

    public ProductsRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Product> GetAll()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM products", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                }
            }
        }
    }

    public Product GetById(int productId)
    {
        // SQL-запит для отримання продукту за ідентифікатором
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM products WHERE productid = @productId", connection);
            command.Parameters.AddWithValue("@productId", productId);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                }
            }
        }
        return null;
    }


    public void Add(string name, int quantity)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("INSERT INTO products (name, quantity) VALUES (@name, @quantity)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.ExecuteNonQuery();
        }
    }

    public void Update(int productId, string name, int quantity)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("UPDATE products SET name = @name, quantity = @quantity WHERE productid = @productId", connection);
            command.Parameters.AddWithValue("@productId", productId);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.ExecuteNonQuery();
        }
    }


    public void Delete(int productId)
    {
        NpgsqlConnection connection = null;
        try
        {
            connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var command = new NpgsqlCommand("DELETE FROM products WHERE productid = @productid", connection);
            command.Parameters.AddWithValue("@productid", productId);
            command.ExecuteNonQuery();
        }
        finally
        {
            connection?.Close();
        }
    }
}
