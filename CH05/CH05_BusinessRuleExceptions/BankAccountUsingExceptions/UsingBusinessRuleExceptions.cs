using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH05_BusinessRuleExceptions.BankAccountUsingExceptions
{
    public class UsingBusinessRuleExceptions
    {
        public void Run()
        {
            ExceedAtmDailyLimit();
            ExceedAvailableBalance();
        }

        private void ExceedAtmDailyLimit()
        {
            try
            {
                var customerAccount = new CurrentAccount(1);
                customerAccount.Withdraw(300);
                Console.WriteLine("Request accepted. Take cash and card.");
            }
            catch (ExceededAtmDailyLimitException eadlex)
            {
                Console.WriteLine(eadlex.Message);
            }
        }

        private void ExceedAvailableBalance()
        {
            try
            {
                var customerAccount = new CurrentAccount(1);
                customerAccount.Withdraw(180);
                Console.WriteLine("Request accepted. Take cash and card.");
            }
            catch (InsufficientFundsException ifex)
            {
                Console.WriteLine(ifex.Message);
            }
        }
    }
}
