using System.Configuration;

namespace CH07_Factories
{
    public class ConcreteFactory : Factory
    {
        private ConnectionStringSettings _connectionStringSettings;

        public ConcreteFactory(string connectionStringName)
        {
            var filepath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            _connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }

        public override IDatabaseConnection FactoryMethod()
        {
            var providerName = _connectionStringSettings.ProviderName;
            var connectionString = _connectionStringSettings.ConnectionString;

            switch (providerName)
            {
                case "System.Data.SqlClient":
                    return new SqlServerDbConnection(connectionString);
                case "System.Data.OracleClient":
                    return new OracleDbConnection(connectionString);
                case "System.Data.MySqlClient":
                    return new OracleDbConnection(connectionString);
                default:
                    return null;
            }
        }
    }
}
