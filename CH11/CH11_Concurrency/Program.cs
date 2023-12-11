using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CH11_Concurrency
{
    class Program
    {
        private static bool _failed;

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.TestConcurrencyAsync();
        }

        private string[] Urls()
        {
            return new string[] {
                "https://docs.microsoft.com/en-gb/",
                "https://samples.postsharp.net/",
                "https://doc.postsharp.net/",
                "https://www.jetbrains.com/products.html#tech=dotnet",
                "https://www.jetbrains.com/resharper/features/",
                "https://www.red-gate.com/solutions/role/development",
                "https://www.devart.com/?AFFILIATE=81902&__c=1",
                "https://www.microsoft.com/en-gb/",
                "https://visualstudio.microsoft.com/",
                "https://www.packtpub.com/gb/free-learning",
                "https://www.microsoft.com/en-gb/sql-server/sql-server-downloads",
                "https://rapidapi.com/",
                "https://finnhub.io/",
                "https://www.helpndoc.com/",
                "https://www.flexera.com/",
                "https://unity.com/",
                "https://www.daz3d.com/",
                "https://www.cryengine.com/"
            };
        }

        private async Task TestConcurrencyAsync()
        {
            IEnumerable<Task<(string Url, string Html)>> tasks = Tasks();
            await ProcessResults(tasks);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private IEnumerable<Task<(string Url, string Html)>> Tasks()
        {
            var httpClient = new HttpClient();
            var tasks = Urls().Select(async (url) =>
            {
                return (Url: url, Html: await httpClient.GetStringAsync(url));
            });
            return tasks;
        }

        private static async Task<T[]> WhenAll<T>(IEnumerable<Task<T>> tasks, int concurrencyLevel)
        {
            if (tasks is ICollection<Task<T>>) 
                throw new ArgumentException(
                    "The enumerable should not be materialized.", 
                    nameof(tasks)
                );
            var locker = new object();
            var results = new List<T>();
            using (var enumerator = tasks.GetEnumerator())
            {
                Task[] workerTasks = BuildArray(concurrencyLevel, locker, results, enumerator);
                await Task.WhenAll(workerTasks).ConfigureAwait(false);
            }
            lock (locker) return results.ToArray();
        }

        private static async Task ProcessResults(IEnumerable<Task<(string Url, string Html)>> tasks)
        {
            var results = await WhenAll(tasks, concurrencyLevel: 2);
            foreach (var (Url, Html) in results)
            {
                Console.WriteLine($"Url: {Url}, {Html.Length:#,0} chars");
            }
        }

        private static Task[] BuildArray<T>(int concurrencyLevel, object locker, List<T> results, IEnumerator<Task<T>> enumerator)
        {
            return Enumerable.Range(0, concurrencyLevel)
                .Select(async _ =>
                {
                    try
                    {
                        while (true)
                        {
                            Task<T> task;
                            int index;
                            lock (locker)
                            {
                                if (_failed) break;
                                if (!enumerator.MoveNext()) break;
                                task = enumerator.Current;
                                index = results.Count;
                                results.Add(default); // Reserve space in the list
                            }
                            var result = await task.ConfigureAwait(false);
                            lock (locker) results[index] = result;
                        }
                    }
                    catch (Exception)
                    {
                        lock (locker) _failed = true;
                        throw;
                    }
                }).ToArray();
        }
    }
}
