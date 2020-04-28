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

        public void Withdraw(uint withDrawAmount, DateTime today)
        {
            var withdraw = new Withdraw(today, withDrawAmount);
            transactions.Add(withdraw);
        }

        public Balance PrintBalance()
        {
            var transactions = this.transactions.GetAll();
            Dictionary<DateTime, int> balance = new Dictionary<DateTime, int>();
            var transactionsPerDay = transactions.GroupBy(t => t.Date);
            foreach (var group in transactionsPerDay)
            {
                balance[group.Key] = group.Sum(t => t.Amount);
            }
            return new Balance(balance);
        }
    }
}