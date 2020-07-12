using System;
using CH11_Instrumentation.Aspects;

namespace CH11_Instrumentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.DoWork();
            program.Broken();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        [InstrumentationAspect]
        public void DoWork()
        {
            Console.WriteLine("I will succeed!");
        }

        [InstrumentationAspect]
        public void Broken()
        {
            throw new NotImplementedException();
        }
    }
}
 