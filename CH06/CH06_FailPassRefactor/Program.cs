using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_FailPassRefactor
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mainException = new Exception(
                "Exception: Main exception.",
                new Exception(
                    "Exception: Inner Exception.",
                    new Exception("Exception: Inner Exception Inner Exception")
                )
            );
            var logger = new Logger();
            LogException(mainException, logger);
            Console.ReadKey();
        }

        private static void LogException(Exception mainException, Logger logger)
        {
            for(var i = 0; i < 10; i++)
            {
                var logFile = logger.Log(mainException);
                Console.WriteLine($"Log File: {logFile}");
                Console.WriteLine($"Exception Logged");
                Console.WriteLine(File.ReadAllText(logFile));
            }
        }
    }
}
