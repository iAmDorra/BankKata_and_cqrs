using System;

namespace Banking
{
    public class BankingService
    {
        private ITransactions transactions;

        public BankingService(ITransactions transactions)
        {
            this.transactions = transactions;
        }

        public void Deposit(uint depositAmount, DateTime today)
        {
            var deposit = new Deposit(today, depositAmount);
            transactions.Add(deposit);
        }

        public void Withdraw(uint withDrawAmount, DateTime today)
        {
            var withdraw = new Withdraw(today, withDrawAmount);
            transactions.Add(withdraw);
        }

        public Balance PrintBalance()
        {
            return this.transactions.GetBalance();
        }

    }
}