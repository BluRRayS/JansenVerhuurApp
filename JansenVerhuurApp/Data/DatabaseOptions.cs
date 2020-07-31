namespace Data
{
    public class DatabaseOptions
    {
        private readonly string _connectionString;

        public DatabaseOptions(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}