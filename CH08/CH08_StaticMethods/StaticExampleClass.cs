using System;
using System.Threading;

namespace CH08_StaticMethods
{
    public static class StaticExampleClass
    {
        private static int _x = 1;
        private static int _y = 2;
        private static int _z = 3;

        static StaticExampleClass()
        {
            Console.WriteLine($"Constructor: _x={_x}, _y={_y}, _z={_z}");
        }

        internal static void ThreadSafeMethod(int x, int y, int z)
        {
            Console.WriteLine($"ThreadSafeMethod: x={x}, y={y}, z={z}");
            Console.WriteLine($"ThreadSafeMethod: {x}+{y}+{z}={x+y+z}");
        }

        internal static void NotThreadSafeMethod(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-NotThreadSafeMethod: _x={_x}, _y={_y}, _z={_z}");
            Thread.Sleep(300);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-ThreadSafeMethod: {_x}+{_y}+{_z}={_x + _y + _z}");
        }
    }
}
