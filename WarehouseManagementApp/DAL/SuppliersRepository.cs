using System.Collections.Generic;
using Npgsql;
using WarehouseManagementApp.Models;


namespace WarehouseManagementApp.DAL
{
    public class SuppliersRepository
    {
        
        private readonly string _connectionString;

        public SuppliersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void Add(string name, string contactInfo)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO suppliers (name, contactinfo) VALUES (@name, @contactInfo)", connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@contactInfo", contactInfo);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int supplierId, string name, string contactInfo)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("UPDATE suppliers SET name = @name, contactinfo = @contactInfo WHERE supplierid = @supplierId", connection);
                command.Parameters.AddWithValue("@supplierId", supplierId);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@contactInfo", contactInfo);
                command.ExecuteNonQuery();
            }
        }

        public Supplier GetById(int supplierId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM suppliers WHERE supplierid = @supplierId", connection);
                command.Parameters.AddWithValue("@supplierId", supplierId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Supplier
                        {
                            SupplierId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ContactInfo = reader.GetString(2)
                        };
                    }
                }
            }
            return null;
        }


        public IEnumerable<Supplier> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM suppliers", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Supplier
                        {
                            SupplierId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ContactInfo = reader.GetString(2)
                        };
                    }
                }
            }
        }


        public void Delete(int supplierId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            var command = new NpgsqlCommand(
                "DELETE FROM suppliers WHERE supplierid = @supplierid",
                connection);
            command.Parameters.AddWithValue("@supplierid", supplierId);
            command.ExecuteNonQuery();
        }
    }
}
