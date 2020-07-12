using System;
using CH14_DesignPatterns.BehavioralDesignPatterns.ChainOfResponsibility;
using CH14_DesignPatterns.BehavioralDesignPatterns.Command;
using CH14_DesignPatterns.CreationalDesignPatterns.AbstractFactory;
using CH14_DesignPatterns.CreationalDesignPatterns.Builder;
using CH14_DesignPatterns.CreationalDesignPatterns.FactoryMethod;
using CH14_DesignPatterns.CreationalDesignPatterns.Prototype;
using CH14_DesignPatterns.CreationalDesignPatterns.Singleton;
using CH14_DesignPatterns.StructuralDesignPatterns.Bridge;
using CH14_DesignPatterns.StructuralDesignPatterns.Composite;
using CH14_DesignPatterns.StructuralDesignPatterns.Facade;
using ConcreteProduct = CH14_DesignPatterns.CreationalDesignPatterns.AbstractFactory.ConcreteProduct;

namespace CH14_DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCreationalExamples();
            //RunStructuralExamples();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #region Creational Design Pattern Examples

        private static void RunCreationalExamples()
        {
            //AbstractFactoryExample();
            //FactoryMethodExample();
            //SingletonExample();
            PrototypeExample();
            //BuilderExample();
        }

        private static void AbstractFactoryExample()
        {
            AbstractFactory factory = new ConcreteProduct();
            Client client = new Client(factory);
            client.Run();
        }

        private static void FactoryMethodExample()
        {
            var creator = new ConcreteCreator();
            var product = creator.FactoryMethod();
            Console.WriteLine($"Product Type: {product.GetType().Name}");
        }

        private static void SingletonExample()
        {
            var instance1 = Singleton.Instance();
            var instance2 = Singleton.Instance();

            if (instance1.Equals(instance2))
                Console.WriteLine("Instance 1 and instance 2 are the same instance of Singleton.");
        }

        private static void PrototypeExample()
        {
            StringConcatenation.UsingThePlusOperator();
            StringConcatenation.UsingTheStringBuilder();
            StringConcatenation.PrintTimeDifference();
            //var prototype = new ConcretePrototype("Clone 1");
            //var clone = (ConcretePrototype)prototype.Clone();
            //Console.WriteLine($"Clone Id: {clone.Id}");
        }

        private static void BuilderExample()
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Build(builder);
            var product = builder.GetProduct();
            product.PrintPartsList();
        }

        #endregion

        #region Structural Design Pattern Examples

        private static void RunStructuralExamples()
        {
            //BridgeExample();
            //CompositeExample();
            //FacadeExample();
            //FlyweightExample();
            //ChainOfResponsibilityExample();
            CommandExample();
        }

        private static void BridgeExample()
        {
            var abstraction = new RefinedAbstraction
            {
                Implementor = new ConcreteImplementor()
            };
            abstraction.Operation();
        }

        private static void CompositeExample()
        {
            var root = new Composite("Classification of Animals");
            var invertebrates = new Composite("- Invertebrates");
            var vertebrates = new Composite("- Vertebrates");

            var warmBlooded = new Leaf("-- Warm-Blooded");
            var coldBlooded = new Leaf("-- Cold-Blooded");
            var withJointedLegs = new Leaf("-- With Jointed-Legs");
            var withoutLegs = new Leaf("-- Without Legs");

            invertebrates.Add(withJointedLegs);
            invertebrates.Add(withoutLegs);

            vertebrates.Add(warmBlooded);
            vertebrates.Add(coldBlooded);

            root.Add(invertebrates);
            root.Add(vertebrates);

            root.PrintName();
        }

        private static void FacadeExample()
        {
            var facade = new Facade();
            facade.SubsystemOneDoWork();
            facade.SubsystemTwoDoWork();
        }

        private static void FlyweightExample()
        {
            var flyweightClient = new StructuralDesignPatterns.Flyweight.Client();
            flyweightClient.ProcessFlyweights();
        }

        private static void ChainOfResponsibilityExample()
        {
            var handlerOne = new ConcreteHandlerOne();
            var handlerTwo = new ConcreteHandlerTwo();

            handlerOne.SetSuccessor(handlerTwo);
            handlerTwo.SetSuccessor(handlerOne);

            handlerOne.HandleRequest("PrintDate");
            handlerOne.HandleRequest("PrintGreeting");
        }

        private static void CommandExample()
        {
            var receiver = new Receiver();
            var command = new ConcreteCommand(receiver);
            var invoker = new Invoker();
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }

        #endregion
    }
}
