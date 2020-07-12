using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH08_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsingTaskParallelLibrary();
            //UsingTaskParallelLibraryFor();
            ThreadPoolQueueUserWorkItem();
        }

        private static void UsingTaskParallelLibrary()
        {
            Message($"UsingTaskParallelLibrary Started: Thread Id = ({Thread.CurrentThread.ManagedThreadId})");
            Parallel.Invoke(MethodOne, MethodTwo, MethodThree);
            Message("UsingTaskParallelLibrary Completed.");
        }

        private static void UsingTaskParallelLibraryFor()
        {
            Message($"UsingTaskParallelLibraryFor Started: Thread Id = ({Thread.CurrentThread.ManagedThreadId})");
            Parallel.For(0, 1000, X => Method());
            Message("UsingTaskParallelLibraryFor Completed.");
        }

        private static void ThreadPoolQueueUserWorkItem()
        {
            ThreadPool.QueueUserWorkItem(WaitCallbackMethod);
            Message("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);
            Message("Main thread exits.");
        }

        private static void WaitCallbackMethod(Object _)
        {
            Message("Hello from WaitCallBackMethod!");
        }

        private static void Method()
        {
            Message($"Method Executed: Thread Id({Thread.CurrentThread.ManagedThreadId})");
        }

        private static void MethodOne()
        {
            Message($"MethodOne Executed: Thread Id({Thread.CurrentThread.ManagedThreadId})");
        }

        private static void MethodTwo()
        {
            Message($"MethodTwo Executed: Thread Id({Thread.CurrentThread.ManagedThreadId})");
        }

        private static void MethodThree()
        {
            Message($"MethodThree Executed: Thread Id({Thread.CurrentThread.ManagedThreadId})");
        }

        private static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
