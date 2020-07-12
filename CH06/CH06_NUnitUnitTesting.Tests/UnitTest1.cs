using NUnit.Framework;
using System;
using System.Diagnostics;

namespace CH06_NUnitUnitTesting.Tests
{
    [TestFixture]
    public sealed class Tests : IDisposable
    {
        private static void WriteSeparatorLine()
        {
            Debug.WriteLine("--------------------------------------------------");
        }

        public Tests()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Constructor");
        }

        public void Dispose()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Dispose");
        }

        [SetUp]
        public void Setup()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Setup");
            Debug.WriteLine("This method is run before each test method is run.");
        }

        [TearDown]
        public void Teardown()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Teardown");
            Debug.WriteLine("This method is run after each test method has been run.");
            Debug.WriteLine("This method runs even when an exception occurs.");
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            WriteSeparatorLine();
            Debug.WriteLine("OneTimeSetUp");
            Debug.WriteLine("This method is run once before any tests in this class are run.");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WriteSeparatorLine();
            Debug.WriteLine("OneTimeTearDown");
            Debug.WriteLine("This method is run once after all tests in this class have been run.");
            Debug.WriteLine("This method runs even when an exception occurs.");
        }

        [Test]
        [Order(1)]
        public void Test2()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Test:Test2");
            Debug.WriteLine("Order: 1");
            Assert.Inconclusive("Test 2 is inconclusive.");
        }

        [Test]
        [Order(0)]
        public void Test1()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Test:Test1");
            Debug.WriteLine("Order: 0");
            Assert.Pass("Test 1 passed with flying colours.");
        }

        [Test]
        [Order(2)]
        public void Test3()
        {
            WriteSeparatorLine();
            Debug.WriteLine("Test:Test3");
            Debug.WriteLine("Order: 2");
            Assert.Fail("Test 1 failed dismally.");
        }
    }
}