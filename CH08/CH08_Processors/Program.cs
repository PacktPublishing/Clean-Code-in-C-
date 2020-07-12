using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH08_Processors
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 in binary is 11, and so the first two cores are used.
            AssignCores(3);
            SetMaxThreads(2, 2);
        }

        /// <summary>
        /// Determine what cores the process will use
        /// </summary>
        /// <param name="cores">
        /// The integer represention of the binary used to determine
        /// which cores will be used by the process.
        /// </param>
        private static void AssignCores(int cores)
        {
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(cores);
        }

        /// <summary>
        /// Sets the number of threads that can be used concurrently.
        /// </summary>
        /// <param name="workerThreads">
        /// The maximum number of worker threads in the thread pool.
        /// </param>
        /// <param name="asyncIoThreads">
        /// The maximum number asynchronous I/O threads in the thread pool.
        /// </param>
        private static void SetMaxThreads(int workerThreads, int asyncIoThreads)
        {
            ThreadPool.SetMaxThreads(workerThreads, asyncIoThreads);
        }
    }
}
