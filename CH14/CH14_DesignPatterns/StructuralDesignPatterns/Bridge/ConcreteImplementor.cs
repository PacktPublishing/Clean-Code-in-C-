using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Bridge
{
    public class ConcreteImplementor : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("Concrete operation executed.");
        }
    }
}
