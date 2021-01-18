using System;
using MySql.Data.MySqlClient;

namespace SingletonProject.DbConnector
{
    public class MySqlConnector
    {
        private static MySqlConnector _connectorInstance;
        private static MySqlConnection _sqlConnection;
        private static object _syncRoot = new object();

        private static readonly string _server = "localhost";
        private static readonly string _database = "rybakova";
        private static readonly string _port = "3307";
        private static readonly string _user = "root";
        private static readonly string _password = "600591";

        private static string _connectionString = $"server={_server};" +
                                                  $"port={_port};" +
                                                  $"database={_database};" +
                                                  $"user={_user};" +
                                                  $"password={_password};";

        private MySqlConnector()
        {
        }

        public static MySqlConnector GetMySqlConnector()
        {
            if (_connectorInstance == null)
            {
                lock (_syncRoot)
                {
                    if (_connectorInstance == null)
                    {
                        _connectorInstance = new MySqlConnector();
                        OpenConnection();
                    }
                }
            }

            return _connectorInstance;
        }

        private static void OpenConnection()
        {
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
            Console.WriteLine("Database connection is established...");
        }

        public void ExecuteQuery(string query)
        {
            if (_sqlConnection != null)
            {
                MySqlCommand command = new MySqlCommand(query, _sqlConnection);
                var result = command.ExecuteScalar().ToString();
                Console.WriteLine("The result of your query: " + result);
            }
            else
            {
                Console.WriteLine("Database connection is NOT established!");
            }
        }

        public void CloseConnection()
        {
            if (_connectorInstance != null)
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
                _connectorInstance = null;
                Console.WriteLine("Database connection is closed...");
            }
        }
    }
}