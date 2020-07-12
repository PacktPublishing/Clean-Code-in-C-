using System;

namespace CH05_BusinessRuleExceptions.BankAccountUsingExceptions
{
    internal class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base()
        {
        }

        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
