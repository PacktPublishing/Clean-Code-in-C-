using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.AbstractFactory
{
    public class ProductA : AbstractProductA
    {
        public override void Operation(AbstractProductB productB)
        {
            Console.WriteLine("ProductA.Operation(ProductB)");
        }
    }
}
