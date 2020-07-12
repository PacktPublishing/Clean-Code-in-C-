using System;
using CrossCuttingConcerns.Validation;

namespace TestHarness
{
    [DisallowNonNullAspect]
    public class ValidationExampleClassTwo
    {
        public ValidationExampleClassTwo() {}

        public ValidationExampleClassTwo(out string value)
        {
            value = null;
        }

        public ValidationExampleClassTwo(string nonNullArg, [AllowNull] string nullArg)
        {
            Console.WriteLine($"{nonNullArg} {nullArg}");
        }

        public void SomeMethod(string nonNullArg, [AllowNull] string nullArg)
        {
            Console.WriteLine(nonNullArg);
            Console.WriteLine(nullArg);
        }

        public string NonNullProperty { get; set; }

        [AllowNull]
        public string NullProperty { get; set; }

        public string PropertyAllowsNullGetButDoesNotAllowNullSet { [return: AllowNull] get; set; }

        public string PropertyAllowsNullSetButDoesNotAllowNullGet { get; [param: AllowNull] set; }

        public int? NonNullNullableProperty { get; set; }

        public string MethodWithReturnValue(bool returnNull)
        {
            return returnNull ? null : "";
        }

        [return: AllowNull]
        public string MethodAllowsNullReturnValue()
        {
            return null;
        }

        public void MethodWithOutValue(out string nonNullOutArg)
        {
            nonNullOutArg = null;
        }

        [DisallowNonNullAspect]
        public void MethodWithOutValueAndException(out string nonNullOutArg)
        {
            nonNullOutArg = null;
            throw new ContextMarshalException();
        }

        public void PublicWrapperOfPrivateMethod()
        {
            SomePrivateMethod(null);
        }

        private void SomePrivateMethod(string x)
        {
            Console.WriteLine($"X: {x}");
        }
    }
}
