using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH05_CustomExceptions
{
    public class TickerListNotFoundException : Exception
    {
        public TickerListNotFoundException() : base()
        {
        }

        public TickerListNotFoundException(string message)
            : base(message)
        {
        }

        public TickerListNotFoundException(
            string message, 
            Exception innerException
        )
            : base(message, innerException)
        {
        }
    }
}
