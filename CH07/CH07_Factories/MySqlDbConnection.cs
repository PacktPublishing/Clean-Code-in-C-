using System;

namespace CH07_Factories
{
    public class MySqlDbConnection : IDatabaseConnection
    {
        public string ConnectionString { get; }

        public MySqlDbConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void CloseConnection()
        {
            Console.WriteLine("MySQL Database Connection Closed.");
        }

        public void OpenConnection()
        {
            Console.WriteLine("MySQL Database Connection Closed.");
        }
    }
}