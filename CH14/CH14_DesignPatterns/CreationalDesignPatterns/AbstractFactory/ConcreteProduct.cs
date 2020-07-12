using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.AbstractFactory
{
    public class ConcreteProduct : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB();
        }
    }
}
