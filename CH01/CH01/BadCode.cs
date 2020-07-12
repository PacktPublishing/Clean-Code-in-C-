using System;
using System.Collections.Generic;
using System.Text;

namespace GoodCodeBadCode.CH01
{
    /// <summary>
    /// This class demonstrates examples of bad code.
    /// </summary>
    public class BadCode
    {
        public int _value; // This is used for storing integer values.
        public string txtName; // This is known as Hungarian notation, and is frowned upon by Microsoft.

        // Example of bad indentation.
        public void DoSomething()
        {
        for (var i = 0; i < 1000; i++)
        {
        var productCode = $"PRC000{i}";
        //...implementation
        int value = GetDataValue(); // This sometimes causes a divide by zero error. Don't know why!
        }
        }

        private int GetDataValue()
        {
        return 100 / DateTime.Now.Second;
        }

        /* No longer used as has been replaced by DoSomething()
        public void IDidSomething()
        {
        // ...implementation...
        }
        */

        public class MyClass
        {
            public void MyMethod()
            {
                // ...implementation...
            }

            public DateTime AddDates(DateTime date1, DateTime date2)
            {
                //...implementation...
                return DateTime.Now;
            }

            public Product GetData(int id)
            {
                //...implementation...
                return new Product();
            }
        }
        public class Product
        {
            public int Id;
            public int Name;
            public int Description;
            public string ProductCode;
            public decimal Price;
            public long UnitsInStock;
        }
    }

    /// <summary>
    /// Example of bad organisation.
    /// </summary>
    namespace MyProject.TextFileMonitor
    {
        public class Program { }
        public class DateTime { }
        public class FileMonitorService { }
        public class Cryptography { }
    }
}
