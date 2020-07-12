using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH08_GeneralRecommendations
{
    class Program
    {
        private static readonly object _lockObject = new object();

        static void Main(string[] args)
        {
            DeadlockRecommendation();
            EndProgram();
        }

        private static void EndProgram()
        {
            Thread.CurrentThread.Join();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void DeadlockRecommendation()
        {
            var args = new[] { "Hello, World!", "Goodbye, World!" };
            for (var index = 0; index < 1000; index++)
            {
                ThreadPool.QueueUserWorkItem(o => InvokeMethod(Message, Message, args));
            }
        }

        private static void InvokeMethod(Action<string> method, Action<string> timeout, string[] args)
        {
            if (Monitor.TryEnter(_lockObject, 1500))
            {
                try
                {
                    method.Invoke(args[0]);

                }
                finally
                {
                    Monitor.Exit(_lockObject);
                }
            }
            else
            {
                timeout.Invoke(args[1]);
            }
        }

        private static void Message(string message)
        {
            Thread.Sleep(500);
            Console.WriteLine(message);
        }
    }
}
