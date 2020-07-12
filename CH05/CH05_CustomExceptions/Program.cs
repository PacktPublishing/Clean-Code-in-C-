using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH05_CustomExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ThrowCustomExceptionA();
            ThrowCustomExceptionB();
            ThrowCustomExceptionC();
        }

        private static void ThrowCustomExceptionA()
        {
            try
            {
                Console.WriteLine("throw new TickerListNotFoundException();");
                throw new TickerListNotFoundException();
            }
            catch (Exception tlnfex)
            {
                Console.WriteLine(tlnfex.Message);
            }
        }

        private static void ThrowCustomExceptionB()
        {
            try
            {
                Console.WriteLine("throw new TickerListNotFoundException(Message);");
                throw new TickerListNotFoundException("Ticker list not found.");
            }
            catch (Exception tlnfex)
            {
                Console.WriteLine(tlnfex.Message);
            }
        }

        private static void ThrowCustomExceptionC()
        {
            try
            {
                Console.WriteLine("throw new TickerListNotFoundException(Message, InnerException);");
                throw new TickerListNotFoundException(
                    "Ticker list not found for this exchange.",
                    new FileNotFoundException(
                        "Ticker list file not found.",
                        @"F:\TickerFiles\LSE\AimTickerList.json"
                    )
                );
            }
            catch (Exception tlnfex)
            {
                Console.WriteLine($"{tlnfex.Message}\n{tlnfex.InnerException}");
            }
        }
    }
}
