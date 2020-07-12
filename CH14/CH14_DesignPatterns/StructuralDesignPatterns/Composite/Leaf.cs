using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Composite
{
    public class Leaf : IComponent
    {
        private readonly string _name;

        public Leaf(string name)
        {
            _name = name;
        }

        public void PrintName()
        {
            Console.WriteLine($"Leaf Name: {_name}");
        }
    }
}
