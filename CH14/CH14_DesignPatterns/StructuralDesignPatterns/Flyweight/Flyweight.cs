using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Flyweight
{
    public abstract class Flyweight
    {
        public abstract void Operation(string extrinsicState);
    }
}
