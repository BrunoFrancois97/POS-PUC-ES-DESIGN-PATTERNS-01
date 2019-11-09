using Aula01;
using Aula01.DataReaders.Contract;
using Aula01.DataReaders.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aula01_Test
{
    [TestClass]
    public class DbConnectionTests
    {
        private readonly IFileDataReader jsonDataReader;

        public DbConnectionTests()
        {
            jsonDataReader = new JSONDataReader();
        }
        [TestMethod]
        public void CreateConnection_FromJSON()
        {
            var connectionString = jsonDataReader.GetConnectionString("C:\\Users\\connection.json");
            var dbConnection = dbConnectionFactory.CreateConnection(DataSource.JSON, connectionString);
            Assert.IsNotNull(dbConnection);
        }

        [TestMethod]
        public void CreateConnection_FromAmbientVariable()
        {
            var connectionString = dataReader.GetConnectionString();
            var dbConnection = dbConnectionFactory.CreateConnection(DataSource.AmbientVariable, connectionString);
            Assert.IsNotNull(dbConnection);
        }

        [TestMethod]
        public void CreateConnection_FromMessage()
        {
            var connectionString = dataReader.GetConnectionString();
            var dbConnection = dbConnectionFactory.CreateConnection(DataSource.Message, connectionString);
            Assert.IsNotNull(dbConnection);
        }
    }
}
