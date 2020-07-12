namespace CH3.DesignForChange
{
    public class Database
    {
        private readonly IConnection _connection;

        public Database(IConnection connection)
        {
            _connection = connection;
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
