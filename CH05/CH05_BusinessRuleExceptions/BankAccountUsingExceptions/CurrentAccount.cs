namespace CH05_BusinessRuleExceptions.BankAccountUsingExceptions
{
    internal class CurrentAccount
    {
        public long CustomerId { get; }
        public decimal AgreedOverdraft { get; }
        public bool IsAllowedToGoOverdrawn { get; }
        public decimal CurrentBalance { get; }
        public decimal AvailableBalance { get; private set; }
        public int AtmDailyLimit { get; }
        public int AtmWithdrawalAmountToday { get; }

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
            if ((amount > AtmDailyLimit) || ((AtmWithdrawalAmountToday + amount) > AtmDailyLimit) && !GetIsAllowedToGoOverdrawn())
                throw new ExceededAtmDailyLimitException(
                    "The maximum daily limit is £250.\nYour request has been denied."
                );
            if (((AtmWithdrawalAmountToday + amount) > AvailableBalance) && !GetIsAllowedToGoOverdrawn())
                throw new InsufficientFundsException(
                    "You have insuffience funds in your account\nYour request has been denied."
                );
            AvailableBalance -= amount;
        }
    }
}
