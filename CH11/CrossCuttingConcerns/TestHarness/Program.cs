using System;
using System.Threading;
using System.Threading.Tasks;
using CrossCuttingConcerns.Exceptions;
using CrossCuttingConcerns.Configuration;
using CrossCuttingConcerns.Security;
using static CrossCuttingConcerns.Configuration.Settings;

namespace TestHarness
{
    internal class Program
    {
        private static readonly ConcreteDecorator ConcreteDecorator = new ConcreteDecorator(new ConcreteSecureComponent());

        private static void Main(string[] _)
        {
            ConfigurationExample();
            // ReSharper disable once ObjectCreationAsStatement
            //new Credentials("End", "User");
            //DoSecureWork();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ConfigurationExample()
        {
            Console.WriteLine(GetAppSetting("Greeting"));
            "Greeting".SetAppSettings("Goodbye, my friends!");
            Console.WriteLine(GetAppSetting("Greeting"));
        }

        private static void ValidationExample()
        {
            var testHarness = new TestClass();
        }

        private static void DoSecureWork()
        {
            AddData();
            EditData();
            DeleteData();
            GetData();
        }

        [ExceptionAspect(consoleOutput: true)]
        private static void AddData()
        {
            ConcreteDecorator.AddData("Hello, world!");
        }

        [ExceptionAspect(consoleOutput: true)]
        private static void EditData()
        {
            ConcreteDecorator.EditData("Update!");
        }

        [ExceptionAspect(consoleOutput: true)]
        private static void DeleteData()
        {
            ConcreteDecorator.DeleteData("Deleting data ...");
        }

        [ExceptionAspect(consoleOutput: true)]
        private static void GetData()
        {
            Console.WriteLine(ConcreteDecorator.GetData("Hacked?"));
        }

        private static async Task RunTestHarnessTests()
        {
            var harness = new TestClass();

            harness.Greetings();
            harness.PerformTransaction();
            harness.ApprovePurchaseOrder();
            Console.WriteLine(harness.GetCachedItem());
            Console.WriteLine(harness.GetCachedItem());
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine(harness.GetCachedItem());
            harness.ResourcePoolExample();

            Console.WriteLine("");

            try
            {
                harness.ValidationExample("Not an email address!");
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }

            harness.RequiresNonNullArgument();

            Console.WriteLine("");

            await harness.TestConcurrencyAsync();
        }
    }
}
