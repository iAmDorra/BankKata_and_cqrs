using System;
using System.Collections.Generic;

namespace Banking
{
    public class BalanceRetriever : IBalanceRetriever
    {
        private Balance balance = new Balance(new Dictionary<DateTime, int>());

        public BalanceRetriever(ITransactions transactions)
        {
            transactions.AddEvent += CalculateBalance;
        }

        public Balance RetrieveBalance()
        {
            return this.balance;
        }

        private void CalculateBalance(object sender, EventArgs e)
        {
            ITransaction transaction = (e as TransactionEventArgs).Transaction;
            this.balance.UpdateDailyAmount(transaction.Date, transaction.Amount);
        }
    }
}
