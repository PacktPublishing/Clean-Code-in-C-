using System;
using System.Diagnostics;

namespace CH05_BusinessRuleExceptions.BankAccountUsingProgramFlow
{
    internal class CurrentAccount
    {
        public long CustomerId { get; }
        public decimal AgreedOverdraft { get; }
        public bool IsAllowedToGoOverdrawn { get; }
        public decimal CurrentBalance { get; }
        public decimal AvailableBalance { get; private set; }
        public int AtmDailyLimit { get; }
        public int AtmWithdrawalAmountToday { get; private set; }

        public CurrentAccount(long customerId)
        {
            CustomerId = customerId;
            AgreedOverdraft = GetAgreedOverdraftLimit();
            IsAllowedToGoOverdrawn = GetIsAllowedToGoOverdrawn();
            CurrentBalance = GetCurrentBalance();
            AvailableBalance = GetAvailableBalance();
            AtmDailyLimit = GetAtmDailyLimit();
            AtmWithdrawalAmountToday = 0;
        }

        private static decimal GetAgreedOverdraftLimit()
        {
            return 0;
        }

        private static bool GetIsAllowedToGoOverdrawn()
        {
            return false;
        }

        private static decimal GetCurrentBalance()
        {
            return 250.00M;
        }

        private static decimal GetAvailableBalance()
        {
            return 173.64M;
        }

        private static int GetAtmDailyLimit()
        {
            return 250;
        }

        public void Withdraw(int amount)
        {
            AvailableBalance -= amount;
        }
    }
}
