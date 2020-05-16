using System.Collections.Generic;

namespace Banking.Application
{
    public class BalanceRetriever : IBalanceRetriever
    {
        private readonly ITransactions transactions;

        public BalanceRetriever(ITransactions transactions)
        {
            this.transactions = transactions;
        }

        public List<AccountStatement> GetStatements()
        {
            var transactions = this.transactions.GetAll();
            var statements = new List<AccountStatement>();

            var balance = 0;
            foreach (var transaction in transactions)
            {
                if (transaction != null)
                {
                    balance += transaction.Amount;
                    statements.Add(new AccountStatement(transaction.Date, transaction.Amount, balance));
                }
            }

            return statements;
        }
    }
}