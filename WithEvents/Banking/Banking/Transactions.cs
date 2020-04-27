using System;
using System.Collections.Generic;

namespace Banking
{
    public class Transactions : ITransactions
    {
        private List<ITransaction> transactions = new List<ITransaction>();

        public void Add(ITransaction transaction)
        {
            transactions.Add(transaction);
        }

        public bool ContainsDeposit(uint amount, DateTime today)
        {
            var transaction = new Deposit(today, amount);
            bool transcationExists = transactions.Contains(transaction);
            return transcationExists;
        }

        public bool ContainsWithdraw(uint amount, DateTime today)
        {
            var transaction = new Withdraw(today, amount);
            bool transcationExists = transactions.Contains(transaction);
            return transcationExists;
        }

        public List<ITransaction> GetAll()
        {
            return new List<ITransaction>(transactions);
        }
    }
}