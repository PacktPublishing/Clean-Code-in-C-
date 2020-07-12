using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Flyweight
{
    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(string extrinsicState)
        {
            Console.WriteLine($"ConcreteFlyweight: {extrinsicState}");
        }
    }
}
