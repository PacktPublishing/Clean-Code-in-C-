using System;
using System.Threading;

namespace CH08_StaticMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            //program.ThreadSafeMethodCall();
            program.ThreadUnsafeMethodCall();
            Console.ReadKey();
        }

        private void ThreadSafeMethodCall()
        {
            for (var index = 0; index < 10; index++)
            {
                var thread = new Thread(() =>
                {
                    StaticExampleClass
                        .ThreadSafeMethod(index + 1, index + 2, index + 3);
                });
                thread.Start();
            }
        }

        private void ThreadUnsafeMethodCall()
        {
            for (var index = 0; index < 10; index++)
            {
                var thread = new Thread(() =>
                {
                    StaticExampleClass
                        .NotThreadSafeMethod(index + 1, index + 2, index + 3);
                });
                thread.Start();
            }
        }

        public static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
