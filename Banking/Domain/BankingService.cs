using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Withdraw(uint withDrawAmount, DateTime dateTime)
        {
            var withdraw = new Withdraw(dateTime, withDrawAmount);
            transactions.Add(withdraw);
        }

        public Balance PrintBalance()
        {
            return new Balance();
        }
    }
}