using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH07_DependencyInjection.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private TextWriter _textWriter;

        [TestInitialize]
        public void Setup()
        {
            DependencyContainer.Register<ILoggerService, LoggerService>();
            DependencyContainer.Register<ConsoleLogger, ConsoleLogger>();
            DependencyContainer.Register<EventLogLogger, EventLogLogger>();
            DependencyContainer.Register<TextFileLogger, TextFileLogger>();
        }

        [TestMethod]
        public void ConsoleTest()
        {
            var consoleLogger = DependencyContainer.Resolve<ConsoleLogger>();
            Assert.IsInstanceOfType(consoleLogger, typeof(ConsoleLogger));
        }

        [TestMethod]
        public void EventLogTest()
        {
            var eventLogger = DependencyContainer.Resolve<EventLogLogger>();
            Assert.IsInstanceOfType(eventLogger, typeof(ConsoleLogger));
        }

        [TestMethod]
        public void TextFileLoggerTest()
        {
            var textFileLogger = DependencyContainer.Resolve<TextFileLogger>();
            Assert.IsInstanceOfType(textFileLogger, typeof(TextFileLogger));
        }
    }
}
