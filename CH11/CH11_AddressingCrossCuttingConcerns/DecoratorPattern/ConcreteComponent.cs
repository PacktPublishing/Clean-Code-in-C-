using CH11_AddressingCrossCuttingConcerns.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_AddressingCrossCuttingConcerns.DecoratorPattern
{
    [Exception]
    public class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            throw new NotImplementedException();
        }
    }
}
