using PostSharp.Patterns.Caching;
using PostSharp.Patterns.Caching.Backends.Redis;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace CH11_Caching
{
    [CacheConfiguration(AbsoluteExpiration = 5)]
    internal class Program
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            LoggingServices.DefaultBackend = new ConsoleLoggingBackend();

            using (RedisServer.Start())
            {
                using (var connection = ConnectionMultiplexer.Connect("localhost:6380,abortConnect = False"))
                {
                    HandleConnectionEvents(connection);
                    RedisCachingBackendConfiguration configuration = GetConfiguration();

                    using (var backend = RedisCachingBackend.Create(connection, configuration))
                    {
                        using (RedisCacheDependencyGarbageCollector.Create(connection, configuration))
                        {
                            CachingServices.DefaultBackend = backend;
                            CachingServices.Profiles["StudentAccount"].AbsoluteExpiration =
                            TimeSpan.FromSeconds(10);
                            TestDirectInvalidation();
                            TestIndirectInvalidation();
                        }
                    }
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
        }

        private static void HandleConnectionEvents(ConnectionMultiplexer connection)
        {
            connection.InternalError += (sender, eventArgs) => Console.Error.WriteLine(eventArgs.Exception);
            connection.ErrorMessage += (sender, eventArgs) => Console.Error.WriteLine(eventArgs.Message);
            connection.ConnectionFailed += (sender, eventArgs) => Console.Error.WriteLine(eventArgs.Exception);
        }

        private static RedisCachingBackendConfiguration GetConfiguration()
        {
            return new RedisCachingBackendConfiguration
            {
                IsLocallyCached = true,
                SupportsDependencies = true
            };
        }

        private static void TestIndirectInvalidation()
        {
            Console.WriteLine("Getting the student account list from the database.");
            StudentAccountServices.GetStudentAccountsOfStudent(1);
            Console.WriteLine("Getting the student account list from the cache.");
            var accounts = StudentAccountServices.GetStudentAccountsOfStudent(1);
            Console.WriteLine("Invalidating the student account list cache.");
            StudentAccountServices.UpdateStudentAccount(accounts.First());
            Console.WriteLine("Getting the student account list from the database.");
            StudentAccountServices.GetStudentAccountsOfStudent(1);
        }

        private static void TestDirectInvalidation()
        {
            Console.WriteLine("Getting student from the database.");
            StudentServices.GetStudent(1);
            Console.WriteLine("Getting the student from the cache.");
            StudentServices.GetStudent(1);
            Console.WriteLine("Invalidating the student cache.");
            StudentServices.UpdateStudent(1, "Lame Duck");
            Console.WriteLine("Getting the student from the database.");
            StudentServices.GetStudent(1);
        }
    }
}
