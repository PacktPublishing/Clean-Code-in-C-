using NUnit.Framework;

namespace CH07_DependencyInjection.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DependencyContainer.Register<ILoggerService, LoggerService>();
        }

        [Test]
        public void EventLogLoggerTest()
        {
            DependencyContainer.Register<EventLogLogger, EventLogLogger>();
            EventLogLogger eventLogLogger = DependencyContainer.Resolve<EventLogLogger>();
            eventLogLogger.Log("Hello Earthlings!");
            var eventLog = new EventLog
        }
    }
}