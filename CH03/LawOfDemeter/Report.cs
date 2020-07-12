namespace CH3.LawOfDemeter
{
    /// <summary>
    /// Report object.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Report()
        {
            Database = new Database();
        }

        /// <summary>
        /// Gets and sets the database connection.
        /// </summary>
        public Database Database { get; set; }

        /// <summary>
        /// Opens a data connection.
        /// </summary>
        public void OpenConnection()
        {
            Database.OpenConnection();
        }
    }
}
