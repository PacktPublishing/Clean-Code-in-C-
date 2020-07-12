using GoodCodeBadCode.RegEx;
using System;

namespace GoodCodeBadCode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidEmail = args[0].IsValidEmail();
            Console.WriteLine("Hello World!");
        }
    }
}
