using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_AddressingCrossCuttingConcerns.DecoratorPattern
{
    public abstract class Decorator : IComponent
    {
        private IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        public virtual void Operation()
        {
            _component.Operation();
        }
    }
}
