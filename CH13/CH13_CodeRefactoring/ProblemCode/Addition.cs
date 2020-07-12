using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_CodeRefactoring.ProblemCode
{
    internal class Addition
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public double Add(double x, double y)
        {
            return x + y;
        }

        public float Add(float x, float y)
        {
            return x + y;
        }
    }
}
