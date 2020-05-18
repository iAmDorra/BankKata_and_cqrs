using System;
using System.Collections.Generic;

namespace Banking.Application
{
    public class Transactions : ITransactions
    {
        private List<ITransaction> transactions = new List<ITransaction>();
        public event EventHandler AddEvent;

        public void Add(ITransaction transaction)
        {
            transactions.Add(transaction);
            AddEvent?.Invoke(null, null);
        }

        public IEnumerable<ITransaction> GetAll()
        {
            return new List<ITransaction>(transactions);
        }
    }
}