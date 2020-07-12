using System;

namespace CH07_Factories
{
    public class SqlServerDbConnection : IDatabaseConnection
    {
        public string ConnectionString { get; }

        public SqlServerDbConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void CloseConnection()
        {
            Console.WriteLine("SQL Server Database Connection Closed.");
        }

        public void OpenConnection()
        {
            Console.WriteLine("SQL Server Database Connection Opened.");
        }
    }
}
