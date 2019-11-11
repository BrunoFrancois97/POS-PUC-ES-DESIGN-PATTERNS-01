namespace Aula01.Configurations
{
    public sealed class OracleConfiguration
    {
        private static OracleConfiguration me;
        private static readonly object padlock = new object();

        public string Host { get; }
        public int PortNumber { get; }
        public string User { get; }
        public string Password { get; }
        public string DbName { get; }

        private OracleConfiguration(string connectionString)
        {
            var data = connectionString.Split(';');
            User = data[0];
            Password = data[1];
            Host = data[2];
            PortNumber = int.Parse(data[3]);
            DbName = data[4];
        }

        public static OracleConfiguration CreateConfiguration(string connectionString)
        {
            if (me == null)
            {
                lock (padlock)
                {
                    me = new OracleConfiguration(connectionString);
                }
            }
            return me;
        }
    }
}
