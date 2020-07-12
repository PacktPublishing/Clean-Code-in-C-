using System;
using System.Linq;
using CrossCuttingConcerns.Caching;
using CrossCuttingConcerns.Exceptions;
using CrossCuttingConcerns.Logging;
using CrossCuttingConcerns.Instrumentation;
using CrossCuttingConcerns.Transactions;
using Microsoft.EntityFrameworkCore;
using PostSharp.Patterns.Diagnostics.Audit;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using TestHarness.Data;
using TestHarness.Models;
using CrossCuttingConcerns.ResourcePooling;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using CrossCuttingConcerns.Concurrency;
using CrossCuttingConcerns.Security;
using CrossCuttingConcerns.Validation;
using PostSharp.Patterns.Contracts;
using Xunit;

namespace TestHarness
{
    public class TestClass
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private DatabaseContext _context = null;

        public TestClass()
        {
            AuditServices.RecordPublished += AuditServices_RecordPublished;
        }

        private void AuditServices_RecordPublished(object sender, AuditRecordEventArgs e)
        {
            var record = new DatabaseAuditRecord(
                WindowsIdentity.GetCurrent().Name,
                (BusinessObject)e.Record.Target,
                e.Record.MemberName,
                e.Record.Text
            );

            record.AppendToDatabase();
        }

        [InstrumentationAspect]
        public void ApprovePurchaseOrder()
        {
            var purchaseOrder = new PurchaseOrder();
            purchaseOrder.Approve();
        }

        [TextFileLogging]
        public void Greetings()
        {
            Console.WriteLine("Hello, world!");
        }

        [ExceptionAspect(true)]
        public void ThrowException()
        {
            throw new NotImplementedException();
        }

        public void PerformTransaction()
        {
            InitialiseDbContext();
            AddBusinesses();
            DisplayBusinessList();
        }

        private void InitialiseDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Businesses")
                .Options;

            _context = new DatabaseContext(options);
        }

        private void AddBusinesses()
        {
            AddBusiness("Microsoft", false);
            AddBusiness("Apple", false);
            AddBusiness("GL Education", true);
            AddBusiness("Oracle", false);
        }

        [RequiresTransactionAspect]
        [ExceptionAspect(false)]
        private void AddBusiness(string name, bool generateException)
        {
            if (generateException)
                throw new ArgumentException();
            var id = _context.Businesses.Count() + 1;
            _context.Businesses.Add(new Business { Id = id, Name = name });
            _context.SaveChanges();
        }

        private void DisplayBusinessList()
        {
            foreach (var business in _context.Businesses)
            {
                Console.WriteLine($"Business: {business.Name}");
            }
        }

        public string GetCachedItem()
        {
            return MemoryCache.GetItem<string>("Message", TimeSpan.FromSeconds(30), GetMessage);
        }

        private string GetMessage()
        {
            return "Hello, world of cache!";
        }

        internal void ResourcePoolExample()
        {
            EnableUserCancel();
            var pool = new ResourcePool<Course>(() => new Course());
            ProcessPoolResources(pool);
        }

        private void ProcessPoolResources(ResourcePool<Course> pool)
        {
            Parallel.For(1, 100, (i, loopState) =>
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

        [ExceptionAspect(false)]
        internal async Task TestConcurrencyAsync()
        {
            var tasks = Tasks();
            await ProcessResults(tasks);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private IEnumerable<string> Urls()
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
        private IEnumerable<Task<(string Url, string Html)>> Tasks()
        {
            var httpClient = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var tasks = Urls().Select(async (url) => (Url: url, Html: await httpClient.GetStringAsync(url)));
            return tasks;
        }

        private static async Task ProcessResults(IEnumerable<Task<(string Url, string Html)>> tasks)
        {
            var results = await ConcurrentProcessorAsync.WhenAll(tasks, concurrencyLevel: 2);
             foreach (var (url, html) in results)
            {
                Console.WriteLine($"Url: {url}, {html.Length:#,0} chars");
            }
        }

        [ConsoleLoggingAspect]
        public void ValidationExample([EmailAddress] string login)
        {
            Console.WriteLine($"Login: {login}");
        }

        [ExceptionAspect(false)]
        public void RequiresNonNullArgument()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new ValidationExampleClassTwo(null, ""));
            Console.WriteLine(exception.Message);
        }

        [ExceptionAspect(false)]
        public void RequiresNonNullForNonPublicMethodWhenAttributeSpecifiesNonPublic()
        {
            var classOne = new ValidationExampleClassOne();
            classOne.DoPublicWork();
            var exception = Assert.Throws<ArgumentNullException>(() => classOne.DoPublicWork());
            Console.WriteLine(exception.Message);
        }
    }
}
