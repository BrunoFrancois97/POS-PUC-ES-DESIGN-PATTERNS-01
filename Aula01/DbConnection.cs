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

        private DbConnection(DbInfo dbInfo)
        {
            Host = dbInfo.Host;
            Port = dbInfo.Port;
            Username = dbInfo.UserName;
            Password = dbInfo.Password;
            DbName = dbInfo.DbName;
        }

        public static DbConnection CreateConnection(DbInfo dbInfo)
        {
            if (me == null)
            {
                lock (padlock)
                {
                    me = new DbConnection(dbInfo);
                }
            }
            return me;
        }
    }
}
