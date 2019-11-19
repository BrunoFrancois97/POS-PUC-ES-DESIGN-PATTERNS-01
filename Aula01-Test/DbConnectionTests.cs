using Aula01.DataReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aula01.Test
{
    [TestClass]
    public class DbConnectionTests
    {
        private readonly JsonDataReader jsonDataReader;
        private readonly DbConnectionFactory dbConnectionFactory;
        private readonly DbConnectionBuilder dbConnectionBuilder;

        public DbConnectionTests()
        {
            jsonDataReader = new JsonDataReader();
            dbConnectionFactory = new DbConnectionFactory();
            dbConnectionBuilder = new DbConnectionBuilder();
        }

        [TestMethod]
        public void CreateConnection_FromJSON_ToSqlServer()
        {
            var connectionString = jsonDataReader.GetConnectionString("C:\\Users\\connection.json");
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.SqlServer, connectionString);
            Assert.IsNotNull(dbConnection);
        }

        [TestMethod]
        public void Execute_FromJSON_ToSqlServer()
        {
            var connectionString = jsonDataReader.GetConnectionString("C:\\Users\\connection.json");
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.SqlServer, connectionString);

            var query = dbConnectionBuilder
                .WithConnection(dbConnection)
                .Ping()
                .TestConnection()
                .Execute("select * from table");

            Assert.AreEqual("select * from table", query);
        }

    }
}
