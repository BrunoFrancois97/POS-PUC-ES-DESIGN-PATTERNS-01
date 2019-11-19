using System;

namespace Aula01
{
    public class DbConnectionBuilder
    {
        private DbConnection dbConnection;
        private bool pinged;
        public DbConnectionBuilder() { }

        public DbConnectionBuilder WithConnection(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            return this;
        }

        public DbConnectionBuilder Ping()
        {
            if(dbConnection == null)
            {
                throw new Exception("db connection not set !");
            }
            pinged = true;
            return this;
        }

        public DbConnection TestConnection()
        {
            if(!pinged)
            {
                throw new Exception("Ping command was not run");
            }
            return dbConnection;
        }
    }
}
