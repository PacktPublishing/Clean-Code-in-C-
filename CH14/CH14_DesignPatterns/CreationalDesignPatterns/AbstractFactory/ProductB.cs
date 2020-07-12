using System;

namespace CH14_DesignPatterns.CreationalDesignPatterns.AbstractFactory
{
    public class ProductB : AbstractProductB
    {
        public override void Operation(AbstractProductA productA)
        {
            Console.WriteLine("ProductB.Operation(ProductA)");
        }
    }
}
