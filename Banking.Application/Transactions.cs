using System.Collections.Generic;

namespace Banking.Application
{
    public class Transactions : ITransactions
    {
        private List<ITransaction> transactions = new List<ITransaction>();

        public void Add(ITransaction transaction)
        {
            transactions.Add(transaction);
        }

        public IEnumerable<ITransaction> GetAll()
        {
            return new List<ITransaction>(transactions);
        }

        public List<AccountStatement> GetStatements()
        {
            var transactions = this.GetAll();
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