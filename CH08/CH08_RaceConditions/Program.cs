using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH08_RaceConditions
{
    class Program
    {
        private static char _alphabetCharacter;

        static void Main(string[] args)
        {
            //Console.WriteLine("\n\nRace Condition:");
            //ThreadingRaceCondition();
            Console.WriteLine("\n\nRace Condition Fixed:");
            ThreadingRaceConditionFixed();
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey();
        }

        static void ThreadingRaceCondition()
        {
            Thread T1 = new Thread(Method1);
            T1.Start();

            Thread T2 = new Thread(Method2);
            T2.Start();
        }

        static void ThreadingRaceConditionFixed()
        {
            Task
                .Run(() => Method1())
                .ContinueWith(task => Method2())
                .Wait();
        }

        static void Method1()
        {
            for (_alphabetCharacter = 'A'; _alphabetCharacter <= 'Z'; _alphabetCharacter ++)
            {
                Console.Write(_alphabetCharacter + " ");
            }
        }

        private static void Method2()
        {
            for (_alphabetCharacter = 'a'; _alphabetCharacter <= 'z'; _alphabetCharacter++)
            {
                Console.Write(_alphabetCharacter + " ");
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void ThisIsASynchronisedMethod()
        {
            Console.WriteLine("Synchronised method called.");
        }

        private int i;
        public int SomeProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return i; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set { i = value; }
        }
    }
}
