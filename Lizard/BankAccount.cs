namespace Lizard
{
    public class BankAccount
    {
        public int Balance { get; set; }

        private readonly ILogBook _logbook;

        public BankAccount(ILogBook logbook)
        {
            _logbook = logbook;
            Balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logbook.Message("Deposit completed");
            _logbook.Message("Test");
            _logbook.LogSeverity = 101;

            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= Balance)
            {
                _logbook.LogToDb("Withdrawal amount: " + amount.ToString());
                Balance -= amount;
                return _logbook.LogBalanceAfterWithdrawal(Balance);
            }
            return _logbook.LogBalanceAfterWithdrawal(Balance - amount);
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
