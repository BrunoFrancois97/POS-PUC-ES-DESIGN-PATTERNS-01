namespace Aula01.Configurations
{
    public sealed class SqlServerConfiguration
    {
        private static SqlServerConfiguration me;
        private static readonly object padlock = new object();

        public string Host { get; }
        public int Port { get; }
        public string Username { get; }
        public string Password { get; }
        public string DbName { get; }

        private SqlServerConfiguration(string connectionString)
        {
            var data = connectionString.Split(';');
            Host = data[0];
            Port = int.Parse(data[1]);
            Username = data[2];
            Password = data[3];
            DbName = data[4];
        }

        public static SqlServerConfiguration CreateConfiguration(string connectionString)
        {
            if (me == null)
            {
                lock (padlock)
                {
                    me = new SqlServerConfiguration(connectionString);
                }
            }
            return me;
        }
    }
}
