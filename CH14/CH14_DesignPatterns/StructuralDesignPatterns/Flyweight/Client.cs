using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH14_DesignPatterns.StructuralDesignPatterns.Flyweight
{
    public class Client
    {
        private const string ExtrinsicState = "Arbitary state can be anything you require!";

        private readonly FlyweightFactory _flyweightFactory = new FlyweightFactory();

        public void ProcessFlyweights()
        {
            var flyweightOne = _flyweightFactory.GetFlyweight("FlyweightOne");
            flyweightOne.Operation(ExtrinsicState);

            var flyweightTwo = _flyweightFactory.GetFlyweight("FlyweightTwo");
            flyweightTwo.Operation(ExtrinsicState);

            var flyweightThree = _flyweightFactory.GetFlyweight("FlyweightThree");
            flyweightThree.Operation(ExtrinsicState);
        }
    }
}
