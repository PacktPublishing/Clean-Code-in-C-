using System;

namespace CH05_BusinessRuleExceptions.BankAccountUsingProgramFlow
{
    public class UsingProgramFlow
    {
        private int _requestedAmount;
        private readonly CurrentAccount _currentAccount;

        public UsingProgramFlow()
        {
            _currentAccount = new CurrentAccount(1);
        }

        public void Run()
        {
            _requestedAmount = 300;
            Console.WriteLine($"Request: Withdraw {_requestedAmount}");
            WithdrawMoney();
            _requestedAmount = 180;
            Console.WriteLine($"Request: Withdraw {_requestedAmount}");
            WithdrawMoney();
            _requestedAmount = 20;
            Console.WriteLine($"Request: Withdraw {_requestedAmount}");
            WithdrawMoney();
        }

        private bool ExceedsDailyLimit()
        {
            return (_requestedAmount > _currentAccount.AtmDailyLimit)
                || (_requestedAmount + _currentAccount.AtmWithdrawalAmountToday > _currentAccount.AtmDailyLimit);
        }

        private bool ExceedsAvailableBalance()
        {
            return _requestedAmount > _currentAccount.AvailableBalance;
        }

        private void WithdrawMoney()
        {
            if (ExceedsDailyLimit())
                Console.WriteLine("Cannot exceed ATM Daily Limit. Request denied.");
            else if (ExceedsAvailableBalance())
                Console.WriteLine("Cannot exceed available balance. You have no agreed overdraft facility. Request denied.");
            else
                Console.WriteLine("Request granted. Take card and cash.");
        }
    }
}
