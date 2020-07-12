using System;
using System.Diagnostics;

namespace CH07_DependencyInjection
{
    internal static class Program
    {

        static void Main(string[] args)
        {
            DependencyContainer.Register<ILoggerService, LoggerService>();
            LogToConsole();
            LogToEventLog();
            LogToTextFile();
        }

        private static void LogText(ILoggerService loggerService)
        {
            loggerService.Log($"Test Mesage: {DateTime.Now}");
        }

        private static void LogToConsole()
        {
            DependencyContainer.Register<ConsoleLogger, ConsoleLogger>();
            ConsoleLogger consoleLogger = DependencyContainer.Resolve<ConsoleLogger>();
            consoleLogger.Log("Hey, World! Ain't life grand...");
        }

        private static void LogToEventLog()
        {
            DependencyContainer.Register<EventLogLogger, EventLogLogger>();
            EventLogLogger eventLogLogger = DependencyContainer.Resolve<EventLogLogger>();
            eventLogLogger.Log("Hello Earthlings!");
            eventLogLogger.Log("Do not proceed to the Moon or Mars.", EventLogEntryType.Warning, 101, 0);
            eventLogLogger.Log("We don't want your space debris.", EventLogEntryType.Error, 999, 0);
        }

        private static void LogToTextFile()
        {
            DependencyContainer.Register<TextFileLogger, TextFileLogger>();
            TextFileLogger textFileLogger = DependencyContainer.Resolve<TextFileLogger>();
            textFileLogger.Log("Supercalafragelisticespialidocious!");
        }
    }
}
