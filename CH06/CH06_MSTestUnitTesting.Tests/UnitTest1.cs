using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CH05_MSTestUnitTesting.Tests
{
    // A class that contains MSTest unit tests. (Required)
    [TestClass]
    public class UnitTest1
    {
        private static void WriteSeparatorLine()
        {
            Debug.WriteLine("--------------------------------------------------");
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            WriteSeparatorLine();
            Debug.WriteLine("Optional: AssemblyInitialize");
            Debug.WriteLine("Executes once before the test run.");
        }

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            WriteSeparatorLine();
            Debug.WriteLine("Optional: ClassInitialize");
            Debug.WriteLine("Executes once for the test class.");
        }

        [TestInitialize]
        public void Setup()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Optional: TestInitialize");
            Debug.WriteLine("Runs before each test.");
        }

        [TestMethod]
        public void TestMethod1()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Required: TestMethod");
            Debug.WriteLine("A test method to be run by the test runner.");
            Debug.WriteLine("This method will appear in the test list.");
            Assert.IsTrue(true);
            Assert.Fail();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Optional: AssemblyCleanup");
            Debug.WriteLine("Executes once after the test run.");
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Optional: ClassCleanup");
            Debug.WriteLine("Runs once after all tests from the class have been executed.");
            Debug.WriteLine("Not guaranteed that it executes instantly after all tests from the class have executed.");
        }

        [TestCleanup]
        public void TearDown()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Optional: TestCleanup");
            Debug.WriteLine("Runs after each test.");
        }
    }
}
