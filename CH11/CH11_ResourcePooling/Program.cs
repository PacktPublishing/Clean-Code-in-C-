using System;
using System.Threading;
using System.Threading.Tasks;

namespace CH11_ResourcePooling
{
    class Program
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        static void Main(string[] args)
        {
            var program = new Program();
            program.RunExample();
        }

        private void RunExample()
        {
            EnableUserCancel();
            var pool = new ResourcePool<Course>(() => new Course());
            ProcessPoolResources(pool);
        }

        private void ProcessPoolResources(ResourcePool<Course> pool)
        {
            Parallel.For(1, 1000000, (i, loopState) =>
            {
                var course = pool.Get();
                try
                {
                    Console.WriteLine($"Student Name: {course.GetStudentById(i)}");
                }
                finally
                {
                    pool.Return(course);
                }

                if (_cancellationTokenSource.Token.IsCancellationRequested)
                    loopState.Stop();
            });
        }

        private void EnableUserCancel()
        {
            _ = Task.Run(() =>
            {
                if (char.ToUpperInvariant(Console.ReadKey().KeyChar) == 'C')
                {
                    _cancellationTokenSource.Cancel();
                }
            });
        }
    }
}
