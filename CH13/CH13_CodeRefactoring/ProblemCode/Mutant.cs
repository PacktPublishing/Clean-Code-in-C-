using CrossCuttingConcerns.Instrumentation;
using System.Collections.Generic;

namespace CH13_CodeRefactoring.ProblemCode
{
    public class Mutant
    {
        [InstrumentationAspect]
        public int IntegerSquaredSum(List<int> integers)
        {
            var squaredSum = 0;
            foreach (var integer in integers)
            {
                squaredSum += integer * integer;
            }
            return squaredSum;
        }
    }
}
