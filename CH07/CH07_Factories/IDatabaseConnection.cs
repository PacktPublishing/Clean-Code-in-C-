namespace CH07_Factories
{
    public interface IDatabaseConnection
    {
        string ConnectionString { get; }
        void OpenConnection();
        void CloseConnection();
    }
}
