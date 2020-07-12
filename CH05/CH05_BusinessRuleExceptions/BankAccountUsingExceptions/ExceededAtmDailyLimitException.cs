using System;

namespace CH05_BusinessRuleExceptions.BankAccountUsingExceptions
{
    internal class ExceededAtmDailyLimitException : Exception
    {
        public ExceededAtmDailyLimitException() : base()
        {
        }

        public ExceededAtmDailyLimitException(string message) : base(message)
        {
        }

        public ExceededAtmDailyLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
