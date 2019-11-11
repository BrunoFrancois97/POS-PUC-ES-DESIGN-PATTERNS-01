namespace Aula01.Configurations
{
    public sealed class PostgreConfiguration
    {
        private static PostgreConfiguration me;
        private static readonly object padlock = new object();

        public string HostName { get; }
        public int PortNumber { get; }
        public string User { get; }
        public string Password { get; }
        public string DatabaseName { get; }

        private PostgreConfiguration(string connectionString)
        {
            var data = connectionString.Split(';');
            DatabaseName = data[0];
            HostName = data[1];
            PortNumber = int.Parse(data[2]);
            User = data[3];
            Password = data[4];
        }

        public static PostgreConfiguration CreateConfiguration(string connectionString)
        {
            if (me == null)
            {
                lock (padlock)
                {
                    me = new PostgreConfiguration(connectionString);
                }
            }
            return me;
        }
    }
}
