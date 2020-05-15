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
            throw new NotImplementedException();
        }

        public void Withdraw(uint withDrawAmount, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Balance PrintBalance()
        {
            throw new NotImplementedException();
        }
    }
}