using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.CreationalDesignPatterns.FactoryMethod
{
    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }
}
