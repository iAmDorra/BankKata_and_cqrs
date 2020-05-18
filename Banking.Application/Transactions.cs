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
            AddEvent?.Invoke(this, new TransactionEventArgs(transaction));
        }

        public IEnumerable<ITransaction> GetAll()
        {
            return new List<ITransaction>(transactions);
        }
    }

    public class TransactionEventArgs : EventArgs
    {
        public TransactionEventArgs(ITransaction transaction)
        {
            Transaction = transaction;
        }

        public ITransaction Transaction { get; private set; }
    }
}