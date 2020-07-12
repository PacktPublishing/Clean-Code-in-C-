using System;

namespace CH3.DesignForChange
{
    public class SqlServerConnection : IConnection
    {
        public void Close()
        {
            Console.WriteLine("Closed SQL Server Connection.");
        }

        public void Open()
        {
            Console.WriteLine("Opened SQL Server Connection.");
        }
    }
}
