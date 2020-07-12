using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CH09_WellDefinedBoundaries
{

    internal class Program
    {
        static void Main(string[] args)
        {
            CreateObjects();
            CreateStructs();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void CreateObjects()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var people = new List<PersonObject>();
            for (var i = 1; i <= 1000000; i++)
            {
                people.Add(new PersonObject { FirstName = "Person", LastName = $"Number {i}" });
            }
            stopwatch.Stop();
            Console.WriteLine($"Object: {stopwatch.ElapsedMilliseconds}, Object Count: {people.Count}");
            GC.Collect();
        }

        private static void CreateStructs()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var people = new List<PersonStruct>();
            for (var i = 1; i <= 1000000; i++)
            {
                people.Add(new PersonStruct("Person", $"Number {i}"));
            }
            stopwatch.Stop();
            Console.WriteLine($"Struct: {stopwatch.ElapsedMilliseconds}, Struct Count: {people.Count}");
            GC.Collect();
        }
    }
}
