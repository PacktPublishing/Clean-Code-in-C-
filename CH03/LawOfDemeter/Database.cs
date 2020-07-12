namespace CH3.LawOfDemeter
{
    /// <summary>
    /// Database object
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Database()
        {
            Connection = new Connection();
        }

        /// <summary>
        /// Gets and sets the connection.
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// Opens a data connection.
        /// </summary>
        public void OpenConnection()
        {
            Connection.Open();
        }
    }
}