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

        public void Deposit(int depositAmount, DateTime today)
        {
            transactions.Add(depositAmount, today);
        }

        public void Withdraw(int withDrawAmount, DateTime today)
        {
            throw new NotImplementedException();
        }

        public Balance PrintBalance()
        {
            throw new NotImplementedException();
        }
    }
}