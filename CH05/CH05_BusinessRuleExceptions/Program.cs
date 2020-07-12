using CH05_BusinessRuleExceptions.BankAccountUsingExceptions;
using CH05_BusinessRuleExceptions.BankAccountUsingProgramFlow;

namespace CH05_BusinessRuleExceptions
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var usingBrExceptions = new UsingBusinessRuleExceptions();
            usingBrExceptions.Run();
            var usingPflow = new UsingProgramFlow();
            usingPflow.Run();
        }
    }
}
