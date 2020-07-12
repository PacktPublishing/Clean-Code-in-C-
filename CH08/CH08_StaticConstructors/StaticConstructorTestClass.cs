using System;
using System.Threading;

namespace CH08_StaticConstructors
{
    public class StaticConstructorTestClass
    {
        private readonly static string _message;

        static StaticConstructorTestClass()
        {
            Console.WriteLine("StaticConstructorTestClass static constructor started.");
            _message = "Hello, World!";
            Thread.Sleep(1000);
            _message = "Goodbye, World!";
            Console.WriteLine("StaticConstructorTestClass static constructor finished.");
        }

        public static string Message()
        {
            return $"Message: {_message}";
        }
    }
}