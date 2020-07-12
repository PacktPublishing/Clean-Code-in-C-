using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.RefactoredCode
{
    internal class Maths
    {
        public T Add<T>(T x, T y)
        {
            dynamic a = x;
            dynamic b = y;
            return a + b;
        }
    }
}
