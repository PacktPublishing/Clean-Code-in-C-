using System;

namespace CH3.DesignForChange
{
    public class MongoDbConnection : IConnection
    {
        public void Close()
        {
            Console.WriteLine("Closed MongoDB connection.");
        }

        public void Open()
        {
            Console.WriteLine("Opened MongoDB connection.");
        }
    }
}
