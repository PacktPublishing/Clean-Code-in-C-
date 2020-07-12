namespace CH3.DependencyInjection
{
    /// <summary>
    /// Example class to show DI in action.
    /// </summary>
    public class Worker
    {
        private ILogger _logger;

        /// <summary>
        /// Constructor injection example.
        /// </summary>
        /// <param name="logger">
        /// The logger that will be injected and
        /// used to log messages.
        /// </param>
        public Worker(ILogger logger)
        {
            _logger = logger;
            _logger.OutputMessage("This constructor has been injected with a logger!");
        }

        /// <summary>
        /// Method injection sample.
        /// </summary>
        /// <param name="logger">
        /// The logger that will be injected and
        /// used to log messages.
        /// </param>
        public void DoSomeWork(ILogger logger)
        {
            logger.OutputMessage("This methods has been injected with a logger!");
        }
    }
}
