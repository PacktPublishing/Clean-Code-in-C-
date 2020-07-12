using CrossCuttingConcerns.Instrumentation;
using System.Collections.Generic;
using System.Linq;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class Function
    {
        [InstrumentationAspect]
        public int IntegerSquaredSum(List<int> integers)
        {
            return integers.Sum(integer => integer * integer);
        }
    }
}
