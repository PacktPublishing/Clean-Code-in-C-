using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH08_Mutability
{
    class Program
    {
        static void Main(string[] args)
        {
            MutableExample();
            Console.ReadKey();
        }

        private static void MutableExample()
        {
            int[] iar = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var mutableClass = new MutableClass(iar);

            Console.WriteLine($"Initial Array: {iar[0]}, {iar[1]}, {iar[2]}, {iar[3]}, {iar[4]}, {iar[5]}, {iar[6]}, {iar[7]}, {iar[8]}, {iar[9]}");

            for (var x = 0; x < 9; x++)
            {

                var thread = new Thread(() =>
                {
                    iar[x] = x + 1;
                    var ia = mutableClass.GetIntArray();
                    Console.WriteLine($"Array [{x}]: {ia[0]}, {ia[1]}, {ia[2]}, {ia[3]}, {ia[4]}, {ia[5]}, {ia[6]}, {ia[7]}, {ia[8]}, {ia[9]}");
                });
                thread.Start();
            }
        }
    }
}
