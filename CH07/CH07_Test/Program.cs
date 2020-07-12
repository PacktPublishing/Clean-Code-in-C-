using System;
using System.Diagnostics;
using System.Linq;

namespace CH07_Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if ((args.Count() > 0) && (args[0].Equals("test")))
            {
                DisplayMainScreen();
            }
            else
            {
                DisplayMainScreenError();
            }
        }

        private static void DisplayMainScreen()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Test Platform Student Console");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Process.Start(@"..\..\..\CH07_Logon\bin\Debug\CH07_Logon.exe");
        }

        private static void DisplayMainScreenError()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Test Platform Student Console");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You must login to use the student module.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Process.Start(@"..\..\..\CH07_Logon\bin\Debug\CH07_Logon.exe");
        }
    }
}
