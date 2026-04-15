using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public static class DatabaseHelper
    {
        private static string _connectionString = @"Server=.;Database=HotelManagementDB02;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}