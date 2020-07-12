using CH09_Proxies.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH09_Proxies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new HelloWorldProxy().GetMessage());
            Console.ReadKey();
        }
    }
}
