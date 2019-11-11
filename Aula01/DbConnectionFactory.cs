using Aula01.Configurations;
using System;

namespace Aula01
{
    public class DbConnectionFactory
    {
        public DbConnection CreateDbConnection(DataBaseType dataBaseType, string connectionString)
        {
            switch (dataBaseType)
            {
                case DataBaseType.SqlServer:
                    return CreateConnectionToSqlServer(connectionString);

                case DataBaseType.Oracle:
                    return CreateConnectionToOracle(connectionString);

                case DataBaseType.Postgre:
                    return CreateConnectionToPostGre(connectionString);

                default:
                    throw new Exception("Invalid DataBase Type");
            }
        }

        private DbConnection CreateConnectionToSqlServer(string connectionString)
        {
            var sqlServerConfiguration = SqlServerConfiguration.CreateConfiguration(connectionString);
            return new DbConnection(sqlServerConfiguration);
        }

        private DbConnection CreateConnectionToOracle(string connectionString)
        {
            var oracleConfiguration = OracleConfiguration.CreateConfiguration(connectionString);
            return new DbConnection(oracleConfiguration);
        }

        private DbConnection CreateConnectionToPostGre(string connectionString)
        {
            var oracleConfiguration = PostgreConfiguration.CreateConfiguration(connectionString);
            return new DbConnection(oracleConfiguration);
        }
    }
}

