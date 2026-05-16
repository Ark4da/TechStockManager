using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace TechStockManager
{
    internal class DB_example
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Port=8889;Database=computeruniverse;Uid=root;Pwd=root;");

        // Method for opening a connection
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Method for closing a connection
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Method for establishing a connection
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
