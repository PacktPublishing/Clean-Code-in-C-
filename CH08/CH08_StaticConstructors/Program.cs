using System;
using System.Threading;

namespace CH08_StaticConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.StaticConstructorExample();
            Thread.CurrentThread.Join();
        }

        private void StaticConstructorExample()
        {
            new Thread(TestStaticConstructor).Start();
            new Thread(TestStaticConstructor).Start();
            new Thread(TestStaticConstructor).Start();
        }

        private void TestStaticConstructor()
        {
            Message($"{Thread.CurrentThread.GetHashCode()}: ClassInitializerInThread() starting.");
            string status = StaticConstructorTestClass.Message();
            Message($"{Thread.CurrentThread.GetHashCode()}: ClassInitializerInThread() status = {status}");
        }

        private static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}