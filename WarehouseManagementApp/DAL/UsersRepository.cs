using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.DAL
{
    public class UsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public (string Role, bool IsValid) ValidateUser(string username, string password)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT role FROM users WHERE username = @username AND password = @password";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    var role = command.ExecuteScalar();
                    return role != null ? (role.ToString(), true) : (null, false);
                }
            }
        }
    }
}
