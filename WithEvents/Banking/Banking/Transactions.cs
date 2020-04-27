using System;
using System.Collections.Generic;

namespace Banking
{
    public class Transactions : ITransactions
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void Add(int amount, DateTime today)
        {
            transactions.Add(new Transaction(today, amount));
        }

        public bool ContainsTransaction(int amount, DateTime today)
        {
            Transaction transaction = new Transaction(today, amount);
            bool transcationExists = transactions.Contains(transaction);
            return transcationExists;
        }
    }
}