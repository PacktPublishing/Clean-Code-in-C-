 using System;
 using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace CrossCuttingConcerns.Concurrency
{
    public class ConcurrentProcessorAsync
    {
        private static bool _failed;

        public static async Task<T[]> WhenAll<T>(IEnumerable<Task<T>> tasks, int concurrencyLevel)
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
                var workerTasks = BuildArray(concurrencyLevel, locker, results, enumerator);
                await Task.WhenAll(workerTasks).ConfigureAwait(false);
            }
            lock (locker) return results.ToArray();
        }

        private static Task[] BuildArray<T>(int concurrencyLevel, object locker, IList<T> results, IEnumerator<Task<T>> enumerator)
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

                            if (task == null) continue;
                            var result = await task.ConfigureAwait(false);
                            lock (locker) results[index] = result;
                        }
                    }
                    catch
                    {
                        lock (locker) _failed = true;
                        throw;
                    }
                }).ToArray();
        }
    }
}
