 using CH11_AddressingCrossCuttingConcerns.Aspects;
using CH11_AddressingCrossCuttingConcerns.DecoratorPattern;
using CH11_AddressingCrossCuttingConcerns.ProxyPattern;
using System;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using CH11_AddressingCrossCuttingConcerns.Attributes;
using PostSharp.Extensibility;
using PostSharp.Patterns.Diagnostics.Audit;

[assembly: Log]
namespace CH11_AddressingCrossCuttingConcerns
{
    [Log(AttributeExclude = true)]
    class Program
    {
        static void Main(string[] args)
        {
            LoggingServices.DefaultBackend = new ConsoleLoggingBackend();
            AuditServices.RecordPublished += AuditServices_RecordPublished;
            DecoratorPatternExample();
            //ProxyPatternExample();
            //SecurityExample();

            //ExceptionHandlingAttributeExample();

            //SuccessfulMethod();
            //FailedMethod();

            Console.ReadKey();
        }

        private static void AuditServices_RecordPublished(object sender, AuditRecordEventArgs e)
        {
            var message = $"Audit: [Member Name: {e.Record.MemberName}, Operation: {e.Record.Text}, Time: {e.Record.Time}]";
            Console.WriteLine(message);
        }

        [Exception]
        private static void ExceptionHandlingAttributeExample()
        {
            throw new NotImplementedException();
        }

        [Audit]
        private static void SecurityExample()
        {
            Login(new LoginData { Login = "login", Password = "password" });
            Login("login", "password");
        }

        private static void Login([ApplyFilters] LoginData loginData)
        {
            Console.WriteLine($"Login={loginData.Login}, Password={loginData.Password}");
        }

        private static void Login(string login, [Reverse] string password)
        {
            Console.WriteLine($"Login={login}, Password={password}");
            ReverseReversedLogin(password);
        }

        public static void ReverseReversedLogin([Reverse] string password)
        {
            Console.WriteLine($"Password: {password}");
        }

        [Audit]
        private static void DecoratorPatternExample()
        {
            var concreteComponent = new ConcreteComponent();
            var concreteDecorator = new ConcreteDecorator(concreteComponent);
            concreteDecorator.Operation();
        }

        private static void ProxyPatternExample()
        {
            Console.WriteLine("### Calling the Service directly. ###");
            var service = new Service();
            service.Request();

            Console.WriteLine("## Calling the Service via a Proxy. ###");
            new Proxy(service).Request();
        }

        [LoggingAspect]
        [Audit]
        private static void SuccessfulMethod()
        {
            Console.WriteLine("Hello World, I am a success!");
        }

        [LoggingAspect]
        [Audit]
        private static void FailedMethod()
        {
            Console.WriteLine("Hello World, I am a failure!");
            var x = 1;
            var y = 0;
            var z = x / y;
        }
    }
}
