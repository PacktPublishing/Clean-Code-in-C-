using System;

namespace CH07_DependencyInjection
{
    public class ConsoleLogger
    {
        private ILoggerService logger = null;

        public ConsoleLogger(ILoggerService loggerService)
        {
            this.logger = loggerService;
        }

        public void Log(string message)
        {
            logger.Log(message);
        }
    }
}
