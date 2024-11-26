using System.Collections.Generic;
using Npgsql;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.DAL
{
    public class OrdersRepository
    {
        private readonly string _connectionString;

        public OrdersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddOrder(int orderId, int productId, int supplierId, int quantity, string status)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO orders (productid, supplierid, quantity, status) VALUES (@productId, @supplierId, @quantity, @status)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("productId", productId);
                    command.Parameters.AddWithValue("supplierId", supplierId);
                    command.Parameters.AddWithValue("quantity", quantity);
                    command.Parameters.AddWithValue("status", status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM orders";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var orders = new List<Order>();
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderId = reader.GetInt32(0),
                                ProductId = reader.GetInt32(1),
                                SupplierId = reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                Status = reader.GetString(4)
                            });
                        }
                        return orders;
                    }
                }
            }
        }


        public Order GetOrderById(int orderId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM orders WHERE orderid = @orderId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("orderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Order
                            {
                                OrderId = reader.GetInt32(0),
                                ProductId = reader.GetInt32(1),
                                SupplierId = reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                Status = reader.GetString(4)
                            };
                        }
                        else
                        {
                            return null; // Повернути null, якщо замовлення не знайдено
                        }
                    }
                }
            }
        }

        public void UpdateOrder(int orderId, int productId, int supplierId, int quantity, string status)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE orders SET productid = @productId, supplierid = @supplierId, quantity = @quantity, status = @status WHERE orderid = @orderId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("productId", productId);
                    command.Parameters.AddWithValue("supplierId", supplierId);
                    command.Parameters.AddWithValue("quantity", quantity);
                    command.Parameters.AddWithValue("status", status);
                    command.Parameters.AddWithValue("orderId", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM orders WHERE orderid = @orderId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("orderId", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
