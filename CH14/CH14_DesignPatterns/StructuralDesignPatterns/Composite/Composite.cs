using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Composite
{
    public class Composite : IComponent
    {
        private readonly string _name;
        private readonly List<IComponent> _components;

        public Composite(string name)
        {
            _name = name;
            _components = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public void PrintName()
        {
            Console.WriteLine($"Composite Name: {_name}");
            foreach (var component in _components)
            {
                component.PrintName();
            }
        }
    }
}
