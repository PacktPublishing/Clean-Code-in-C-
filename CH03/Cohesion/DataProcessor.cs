namespace CH3.Cohesion
{
    /// <summary>
    /// This class demonstrates high cohesion,
    /// and obeys the SRP.
    /// </summary>
    public class DataProcessor
    {
        /// <summary>
        /// Obtain the data for the report.
        /// </summary>
        public void ExtractDataFromDataSource() { }

        /// <summary>
        /// Shape the data for the report.
        /// </summary>
        public void TransformDataForReport() { }
    }
}
