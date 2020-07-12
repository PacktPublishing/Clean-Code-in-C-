namespace CH3.LawOfDemeter
{
    /// <summary>
    /// Good and bad examples of the 
    /// Law of Demeter.
    /// </summary>
    public class Example
    {
        /// <summary>
        /// Breaks the Law of Demeter because
        /// the getters are returning different
        /// objects.
        /// </summary>
        public void BadExample_Chaining()
        {
            var report = new Report();
            report.Database.Connection.Open();
        }

        /// <summary>
        /// This example respects the 
        /// Law of Demeter because it only calls
        /// an immediate method on an object held
        /// in an instance variable.
        /// </summary>
        public void GoodExample()
        {
            var report = new Report();
            report.OpenConnection();
        }
    }
}
