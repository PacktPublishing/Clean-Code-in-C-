using System;

namespace CH07_Factories
{
    public class OracleDbConnection : IDatabaseConnection
    {
        public string ConnectionString { get; }

        public OracleDbConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void CloseConnection()
        {
            Console.WriteLine("Oracle Database Connection Closed.");
        }

        public void OpenConnection()
        {
            Console.WriteLine("Oracle Database Connection Closed.");
        }
    }
}