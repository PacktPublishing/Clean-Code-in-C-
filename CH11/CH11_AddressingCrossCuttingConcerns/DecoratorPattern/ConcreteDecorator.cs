using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_AddressingCrossCuttingConcerns.DecoratorPattern
{
    public class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(IComponent component) 
            : base(component) { }

        public override void Operation()
        {
            try
            {
                Console.WriteLine("Operation: try block.");
                base.Operation();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Operation: catch block.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
