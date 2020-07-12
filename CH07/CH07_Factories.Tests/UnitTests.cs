using NUnit.Framework;

namespace CH07_Factories.Tests
{
    public class Tests
    {
        [Test]
        public void IsSqlServerDbConnection()
        {
            var factory = new ConcreteFactory("SqlServer");
            var connection = factory.FactoryMethod();
            Assert.IsInstanceOf<SqlServerDbConnection>(connection);
        }

        [Test]
        public void IsOracleDbConnection()
        {
            var factory = new ConcreteFactory("Oracle");
            var connection = factory.FactoryMethod();
            Assert.IsInstanceOf<OracleDbConnection>(connection);
        }

        [Test]
        public void IsMySqlDbConnection()
        {
            var factory = new ConcreteFactory("MySQL");
            var connection = factory.FactoryMethod();
            Assert.IsInstanceOf<MySqlDbConnection>(connection);
        }
    }
}