namespace CH3.DependencyInjection
{
    /// <summary>
    /// Logging interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Outputs the message depending upon
        /// the implementation.
        /// </summary>
        /// <param name="message">
        /// The message to be logged.
        /// </param>
        void OutputMessage(string message);
    }
}
