using NUnit.Framework;
using System;
using System.IO;

namespace CH06_FailPassRefactor
{
    [TestFixture]
    public class UnitTests
    {
        // The PseudoCode.
        // [1] Call a method to log an exception.
        [Test]
        public void LogException()
        {
            var logger = new Logger();
            var logFileName = logger.Log(new ArgumentException("Argument cannot be null"));
            Assert.Pass();
        }
        // [2] Build up the text to log including 
        //     all inner exceptions.
        // [3] Write the text to a file with a timestamp.
        private Exception GetException()
        {
            return new Exception(
                "Exception: Main exception.",
                new Exception(
                    "Exception: Inner Exception.",
                    new Exception("Exception: Inner Exception Inner Exception")
                )
            );
        }

        [Test]
        public void CheckFileExists()
        {
            var logger = new Logger();
            var logFile = logger.Log(GetException());
            FileAssert.Exists(logFile);
        }

        [Test]
        public void ContainsMessage()
        {
            var logger = new Logger();
            var logFile = logger.Log(GetException());
            var msg = File.ReadAllText(logFile);
            Assert.IsTrue(msg.Contains("Exception: Inner Exception Inner Exception"));
        }
    }
}
