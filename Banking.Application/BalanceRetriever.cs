using System.Collections.Generic;

namespace Banking.Application
{
    public class BalanceRetriever : IBalanceRetriever
    {
        private readonly Transactions transactions;
        private List<AccountStatement> statements = new List<AccountStatement>();
        private int balance = 0;

        public BalanceRetriever(Transactions transactions)
        {
            this.transactions = transactions;
            this.transactions.AddEvent += HandleAddTransactionEvent;
        }

        private void HandleAddTransactionEvent(object sender, TransactionEventArgs e)
        {
            var transaction = e.Transaction;
            balance += transaction.Amount;
            statements.Add(new AccountStatement(transaction.Date, transaction.Amount, balance));
        }

        public List<AccountStatement> GetStatements()
        {
            return statements;
        }
    }
}