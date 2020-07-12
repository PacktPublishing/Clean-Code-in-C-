using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_Factories
{
    internal static class Program
    {

        private static void Main(string[] args)
        {
            var b = new ConcreteFactory("MySQL");
            var c = b.FactoryMethod();
        }
    }
}
