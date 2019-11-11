using Aula01.Configurations;

namespace Aula01
{
    public sealed class DbConnection
    {
        public string Host { get; }
        public int Port { get; }
        public string Username { get; }
        public string Password { get; }
        public string DbName { get; }

        public DbConnection(SqlServerConfiguration sqlServerConfiguration)
        {
            Host = sqlServerConfiguration.Host;
            Port = sqlServerConfiguration.Port;
            Username = sqlServerConfiguration.Username;
            Password = sqlServerConfiguration.Password;
            DbName = sqlServerConfiguration.DbName;
        }

        public DbConnection(PostgreConfiguration sqlServerConfiguration)
        {
            Host = sqlServerConfiguration.HostName;
            Port = sqlServerConfiguration.PortNumber;
            Username = sqlServerConfiguration.User;
            Password = sqlServerConfiguration.Password;
            DbName = sqlServerConfiguration.DatabaseName;
        }

        public DbConnection(OracleConfiguration sqlServerConfiguration)
        {
            Host = sqlServerConfiguration.Host;
            Port = sqlServerConfiguration.PortNumber;
            Username = sqlServerConfiguration.User;
            Password = sqlServerConfiguration.Password;
            DbName = sqlServerConfiguration.DbName;
        }


    }
}
