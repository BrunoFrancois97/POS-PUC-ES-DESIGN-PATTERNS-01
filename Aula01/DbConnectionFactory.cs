namespace Aula01
{
    public class DbConnectionFactory
    {
        //TODO: maybe use a builder instead
        public DbConnection CreateDbConnection(DataSource dataSource, string connectionString)
        {
            switch (dataSource)
            {
                case DataSource.JSON:
                   return CreateConnectionFromJSON(connectionString);

                case DataSource.AmbientVariable:
                    //TODO: Create Factory Method
                    return new DbConnection();

                case DataSource.Message:
                    //TODO: Create Factory Method
                    return new DbConnection();

                default:
                    return new DbConnection();
            }
        }

        private DbConnection CreateConnectionFromJSON(string connectionString)
        {
            return new DbConnection();
        }
    }
}

