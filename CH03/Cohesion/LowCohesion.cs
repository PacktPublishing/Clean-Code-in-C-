namespace CH3.Cohesion
{
    /// <summary>
    /// This is an example of low cohesion. The class can be broken
    /// down into 3 classes that are more cohesive. Let us see the
    /// multiple responsibilities of this class. They are:
    /// 
    /// [1] Connecting to and disconnecting to a data source.
    /// [2] Extracting and transforming data.
    /// [3] Generating and printing a report.
    /// </summary>
    public class LowCohesion
    {
        /// <summary>
        /// Establish a connection to a datasource.
        /// </summary>
        public void ConnectToDatasource() { }

        /// <summary>
        /// Obtain the data for the report.
        /// </summary>
        public void ExtractDataFromDataSource() { }

        /// <summary>
        /// Shape the data for the report.
        /// </summary>
        public void TransformDataForReport() { }

        /// <summary>
        /// Load the report and fill with data.
        /// </summary>
        public void AssignDataAndGenerateReport() { }

        /// <summary>
        /// Print the report.
        /// </summary>
        public void PrintReport() { }

        /// <summary>
        /// Close the connection to the data source and release resources.
        /// </summary>
        public void CloseConnectionToDataSource() { }
    }
}
