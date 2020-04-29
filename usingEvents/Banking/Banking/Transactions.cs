﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Transactions : ITransactions
    {
        private List<ITransaction> transactions = new List<ITransaction>();
        private Balance balance;

        public Transactions()
        {
            this.AddEvent += CalculateBalance;
            this.balance = new Balance(new Dictionary<DateTime, int>());
        }

        private void CalculateBalance(object sender, EventArgs e)
        {
            ITransaction transaction = (e as TransactionEventArgs).Transaction;
            this.balance.UpdateDailyAmount(transaction.Date, transaction.Amount);
        }

        public event EventHandler AddEvent;

        public void Add(ITransaction transaction)
        {
            transactions.Add(transaction);
            AddEvent?.Invoke(this, new TransactionEventArgs(transaction));
        }

        public Balance RetreiveBalance()
        {
            return this.balance;
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

        public Balance GetBalance()
        {
            var transactions = this.GetAll();
            Dictionary<DateTime, int> balance = new Dictionary<DateTime, int>();
            var transactionsPerDay = transactions.GroupBy(t => t.Date);
            foreach (var group in transactionsPerDay)
            {
                balance[group.Key] = group.Sum(t => t.Amount);
            }
            return new Balance(balance);
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