using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_ExceptionHandling
{
    public class CustomException : Exception
    {
        public CustomException() : base() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception innerException) : base(message, innerException) {}

        public int Status { get; set; }
    }
}
