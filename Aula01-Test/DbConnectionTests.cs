using Aula01;
using Aula01.DataReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aula01_Test
{
    [TestClass]
    public class DbConnectionTests
    {
        private readonly JsonDataReader jsonDataReader;
        private readonly DbConnectionFactory dbConnectionFactory;

        public DbConnectionTests()
        {
            jsonDataReader = new JsonDataReader();
            dbConnectionFactory = new DbConnectionFactory();
        }
        [TestMethod]
        public void CreateConnection_FromJSON()
        {
            var connectionString = jsonDataReader.GetConnectionString("C:\\Users\\connection.json");
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.SqlServer, connectionString);
            Assert.IsNotNull(dbConnection);
        }

        [TestMethod]
        public void CreateConnection_FromAmbientVariable()
        {
            var connectionString = jsonDataReader.GetConnectionString("");
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.Oracle, connectionString);
            Assert.IsNotNull(dbConnection);
        }

        [TestMethod]
        public void CreateConnection_FromMessage()
        {
            var connectionString = jsonDataReader.GetConnectionString("");
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.Postgre, connectionString);
            Assert.IsNotNull(dbConnection);
        }
    }
}
