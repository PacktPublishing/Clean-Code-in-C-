using System;
using System.Collections.Generic;
using System.Text;

namespace GoodCodeBadCode.CH01
{
    /// <summary>
    /// This class demonstrates examples of good code.
    /// </summary>
    public class GoodCode
    {
        /// <summary>
        /// Example of proper indentaton.
        /// </summary>
        public void DoSomething()
        {
            for (var i = 0; i < 1000; i++)
            {
                var productCode = $"PRC000{i}";
                //...implementation
            }
        }

        /// <summary>
        /// Concatenates names in reverse order.
        /// </summary>
        /// <param name="firstName">The person's first name</param>
        /// <param name="lastName">The person's last name</param>
        /// <returns></returns>
        public string ConcatName(string firstName, string lastName)
        {
            return $"{lastName}, {firstName}";
        }
    }

    namespace CompanyName.ProductName.RegEx
    {
        using System;
        using System.Text.RegularExpressions;

        /// <summary>
        /// An extension class for providing regular expression extensions methods.
        /// </summary
        public static class RegularExpressions
        {
            private static string _preprocessed;

            public static string RegularExpression { get; set; }

            public static bool IsValidEmail(this string email)
            {
                // Email address: RFC 2822 Format. 
                // Matches a normal email address. Does not check the top-level domain.
                // Requires the "case insensitive" option to be ON.
                var exp = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                bool isEmail = Regex.IsMatch(email, exp, RegexOptions.IgnoreCase);
                return isEmail;
            }

            // ... rest of the implementation ...

        }
    }

    public class Worker
    {
        public void DoSomeWork()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                // Perform unit of work here.
            }
            // At this point the unit of work object has been disposed of.
        }
    }

    public class UnitOfWork : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// The namespace contains classes that define file and directory operations
    /// </summary>
    namespace CompanyName.IO.FileSystem
    {
        public class File { }
        public class Directory { }
    }

    /// <summary>
    /// The namespace contains classes for performing various conversion operations
    /// </summary>
    namespace CompanyName.Converters
    {
        public class BindingTypeConverter { }
        public class BoolNegationConverter { }
    }

    /// <summary>
    /// The namespace contains types for managing stream input and output
    /// </summary>
    namespace CompanyName.Streams
    {
        public class FileStream { }
        public class MemoryStream { }
    }
}
