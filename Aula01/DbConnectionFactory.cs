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
            var data = connectionString.Split(';');
            var dbConfiguration = new DbConfiguration
            {
                Host = data[0],
                Port = int.Parse(data[1]),
                UserName = data[2],
                Password = data[3],
                DbName = data[4],
            };
            return DbConnection.CreateConnection(dbConfiguration);
        }

        private DbConnection CreateConnectionToOracle(string connectionString)
        {
            var dbInfo = new DbConfiguration();
            return DbConnection.CreateConnection(dbInfo);
        }

        private DbConnection CreateConnectionToPostGre(string connectionString)
        {
            var dbInfo = new DbConfiguration();
            return DbConnection.CreateConnection(dbInfo);
        }
    }
}

