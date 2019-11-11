using Aula01.DataReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aula01.Test
{
    [TestClass]
    public class DbConnectionTests
    {
        private readonly JsonDataReader jsonDataReader;
        private readonly AmbientVariableDataReader ambientVariableDataReader;
        private readonly DbConnectionFactory dbConnectionFactory;

        public DbConnectionTests()
        {
            jsonDataReader = new JsonDataReader();
            dbConnectionFactory = new DbConnectionFactory();
            ambientVariableDataReader = new AmbientVariableDataReader();
        }
        [TestMethod]
        public void CreateConnection_FromJSON_ToSqlServer()
        {
            var connectionString = jsonDataReader.GetConnectionString("C:\\Users\\connection.json");
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.SqlServer, connectionString);
            Assert.IsNotNull(dbConnection);
        }

        [TestMethod]
        public void CreateConnection_FromAmbientVariabl_ToOracle()
        {
            var connectionString = ambientVariableDataReader.GetConnectionString();
            var dbConnection = dbConnectionFactory.CreateDbConnection(DataBaseType.Oracle, connectionString);
            Assert.IsNotNull(dbConnection);
        }
    }
}
