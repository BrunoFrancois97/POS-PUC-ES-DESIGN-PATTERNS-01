namespace Aula01
{
    public sealed class DbConnection
    {
        private static DbConnection me;
        private static readonly object padlock = new object();

        private readonly string Host;
        private readonly int Port;
        private readonly string Username;
        private readonly string Password;
        private readonly string DbName;

        private DbConnection(DbConfiguration dbConfiguration)
        {
            Host = dbConfiguration.Host;
            Port = dbConfiguration.Port;
            Username = dbConfiguration.UserName;
            Password = dbConfiguration.Password;
            DbName = dbConfiguration.DbName;
        }

        public static DbConnection CreateConnection(DbConfiguration dbConfiguration)
        {
            if (me == null)
            {
                lock (padlock)
                {
                    me = new DbConnection(dbConfiguration);
                }
            }
            return me;
        }
    }
}
