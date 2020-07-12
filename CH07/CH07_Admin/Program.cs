using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_Admin
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if ((args.Count() > 0) && (args[0].Equals("admin")))
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
            Console.WriteLine("Test Platform Administrator Console");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Process.Start(@"..\..\..\CH07_Logon\bin\Debug\CH07_Logon.exe");
        }

        private static void DisplayMainScreenError()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Test Platform Administrator Console");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You must login to use the admin module.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Process.Start(@"..\..\..\CH07_Logon\bin\Debug\CH07_Logon.exe");
        }
    }
}
