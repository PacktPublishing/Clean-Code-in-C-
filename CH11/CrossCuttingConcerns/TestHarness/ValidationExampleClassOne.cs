using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCuttingConcerns.Validation;

namespace TestHarness
{
    [DisallowNonNullAspect(ValidationFlags.NonPublic | ValidationFlags.Methods | ValidationFlags.Arguments)]
    public class ValidationExampleClassOne
    {
        [AllowNull] public string Name { get; set; }

        public void DoPublicWork()
        {
            DoPrivateWork(null);
        }

        private void DoPrivateWork(string value)
        {
            Console.WriteLine($"Value: {value}");
        }
    }
}
