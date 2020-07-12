using System;

namespace CrossCuttingConcerns.Security
{
    public class ConcreteSecureComponent : ISecureComponent
    {
        public void AddData(dynamic data)
        {
            Console.WriteLine($"Adding data...{data}");
        }

        public int DeleteData(dynamic data)
        {
            Console.WriteLine("Deleting data...");
            return 1;
        }

        public int EditData(dynamic data)
        {
            Console.WriteLine("Updating data...");
            return 1;
        }

        public dynamic GetData(dynamic data)
        {
            Console.WriteLine("Getting data...");
            return "Hi!";
        }
    }
}
