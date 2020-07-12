using System;
using System.Threading;

namespace CH08_ThreadsIntro
{
    class Program
    {
        private static readonly Mutex _mutex;
        private static readonly Semaphore _semaphore;

        static void Main(string[] args)
        {
            SynchronousProcessing();
            ParallelProcessingUsingForegroundThreads();
            ParallelProcessingUsingBackgroundThreads();
            Console.ReadKey();
        }

        internal static void Message(string message)
        {
            Console.WriteLine(message);
        }

        internal static void ThreadDelay(TimeSpan timeSpan)
        {
            Thread.Sleep(timeSpan);
        }

        private static void SynchronousProcessing()
        {
            Method1();
            Method2();
        }

        private static void ParallelProcessingUsingForegroundThreads()
        {
            var method1Thread = new Thread(Method1);
            var method2Thread = new Thread(Method2);
            method1Thread.Start();
            method2Thread.Start();
        }

        private static void ParallelProcessingUsingBackgroundThreads()
        {
            var method3Thread = new Thread(Method3);
            method3Thread.IsBackground = true;
            method3Thread.Start();
            Console.WriteLine("Main application exited.");
        }

        private static void Method1()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method 1 Executed: {i}");
                Thread.Sleep(500);
            }
        }

        private static void Method2()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method 2 Executed: {i}");
                Thread.Sleep(500);
            }
        }

        private static void Method3()
        {
            Console.WriteLine("Method 3: Entered");
            Console.ReadKey();
            Console.WriteLine("Method 3: Exited");
        }



        private static void ForegroundThreadExample()
        {
            var foregroundThread = new Thread(() => {
                Message("Foreground Thread");
            });
            foregroundThread.Start();
        }

        private static void BackgroundThreadExample()
        {
            var backgroundThread = new Thread(() =>
            {
                Message("Background Thread");
            })
            {
                IsBackground = true
            };
            backgroundThread.Start();
        }

        private static void ThreadParametersExample()
        {
            int result = 0;
            Thread thread = new Thread(() => { result = Add(1, 2); });
            thread.Start();
            thread.Join();
            Message($"The addition of 1 plus 2 is {result}.");
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static void MutexExample()
        {
            for (var i = 1; i <= 10; i++)
            {
                var thread = new Thread(ThreadSynchronisationUsingMutex)
                {
                    Name = $"Mutex Example Thread: {i}"
                };
                thread.Start();
            }
        }

        private static void ThreadSynchronisationUsingMutex()
        {
            try
            {
                _mutex.WaitOne();
                Message($"Domain Entered By: {Thread.CurrentThread.Name}");
                Thread.Sleep(500);
                Message($"Domain Left By: {Thread.CurrentThread.Name}");
            }
            catch
            {
                _mutex.ReleaseMutex();
            }
        }

        private static void SemaphoreExample()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread t = new Thread(StartSemaphore);
                t.Start(i);
            }
        }

        private static void StartSemaphore(object id)
        {
            Console.WriteLine($"Object {id} wants semaphore access.");
            try
            {
                _semaphore.WaitOne();
                Console.WriteLine($"Object {id} gained semaphore access.");
                Thread.Sleep(1000);
                Console.WriteLine($"Object {id} has exited semaphore.");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
