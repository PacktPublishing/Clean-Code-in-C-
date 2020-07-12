namespace CH3.Cohesion
{
    /// <summary>
    /// This class demonstrates high cohesion,
    /// and obeys the SRP.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Establish a connection to a datasource.
        /// </summary>
        public void ConnectToDatasource() { }

        /// <summary>
        /// Close the connection to the data source and release resources.
        /// </summary>
        public void CloseConnectionToDataSource() { }
    }
}
