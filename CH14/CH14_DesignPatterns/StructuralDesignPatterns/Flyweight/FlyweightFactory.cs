using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Flyweight
{
    public class FlyweightFactory
    {
        private readonly Hashtable _flyweights = new Hashtable();

        public FlyweightFactory()
        {
            _flyweights.Add("FlyweightOne", new ConcreteFlyweight());
            _flyweights.Add("FlyweightTwo", new ConcreteFlyweight());
            _flyweights.Add("FlyweightThree", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)_flyweights[key]);
        }
    }
}
