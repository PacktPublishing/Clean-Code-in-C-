using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH08_Deadlocks
{
    class Program
    {
        static object _object1 = new object();
        static object _object2 = new object();

        private static void Thread1Method()
        {
            Console.WriteLine("Thread1Method: Thread1Method Entered.");
            lock (_object1)
            {
                Console.WriteLine("Thread1Method: Entered _object1 lock. Sleeping...");
                Thread.Sleep(1000);
                Console.WriteLine("Thread1Method: Woke from sleep");
                lock (_object2)
                {
                    Console.WriteLine("Thread1Method: Entered _object2 lock.");
                }
                Console.WriteLine("Thread1Method: Exited _object2 lock.");
            }
            Console.WriteLine("Thread1Method: Exited _object1 lock.");
        }

        private static void Thread2Method()
        {
            Console.WriteLine("Thread2Method: Thread1Method Entered.");
            lock (_object2)
            {
                Console.WriteLine("Thread2Method: Entered _object2 lock. Sleeping...");
                Thread.Sleep(1000);
                Console.WriteLine("Thread2Method: Woke from sleep.");
                lock (_object1)
                {
                    Console.WriteLine("Thread2Method: Entered _object1 lock.");
                }
                Console.WriteLine("Thread2Method: Exited _object1 lock.");
            }
            Console.WriteLine("Thread2Method: Exited _object2 lock.");
        }

        private static void DeadlockNoRecovery()
        {
            Thread thread1 = new Thread((ThreadStart)Thread1Method);
            Thread thread2 = new Thread((ThreadStart)Thread2Method);

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void Main()
        {
            // DeadlockNoRecovery();
            DeadlockWithRecovery();
        }

        private static void DeadlockWithRecovery()
        {
            Thread thread4 = new Thread((ThreadStart)Thread4Method);
            Thread thread5 = new Thread((ThreadStart)Thread5Method);

            thread4.Start();
            thread5.Start();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void Thread4Method()
        {
            Console.WriteLine("Thread4Method: Entered _object1 lock. Sleeping...");
            Thread.Sleep(1000);
            Console.WriteLine("Thread4Method: Woke from sleep");
            if (!Monitor.TryEnter(_object1))
            {
                Console.WriteLine("Thead4Method: Failed to lock _object1.");
                return;
            }
            try
            {
                if (!Monitor.TryEnter(_object2))
                {
                    Console.WriteLine("Thread4Method: Failed to lock _object2.");
                    return;
                }
                try
                {
                    Console.WriteLine("Thread4Method: Doing work with _object2.");
                }
                finally
                {
                    Monitor.Exit(_object2);
                    Console.WriteLine("Thread4Method: Released _object2 lock.");
                }
            }
            finally
            {
                Monitor.Exit(_object1);
                Console.WriteLine("Thread4Method: Released _object2 lock.");
            }
        }

        private static void Thread5Method()
        {
            Console.WriteLine("Thread5Method: Entered _object2 lock. Sleeping...");
            Thread.Sleep(1000);
            Console.WriteLine("Thread5Method: Woke from sleep");
            if (!Monitor.TryEnter(_object2))
            {
                Console.WriteLine("Thead5Method: Failed to lock _object2.");
                return;
            }
            try
            {
                if (!Monitor.TryEnter(_object1))
                {
                    Console.WriteLine("Thread5Method: Failed to lock _object1.");
                    return;
                }
                try
                {
                    Console.WriteLine("Thread5Method: Doing work with _object1.");
                }
                finally
                {
                    Monitor.Exit(_object1);
                    Console.WriteLine("Thread5Method: Released _object1 lock.");
                }
            }
            finally
            {
                Monitor.Exit(_object2);
                Console.WriteLine("Thread5Method: Released _object2 lock.");
            }
        }
    }
}
