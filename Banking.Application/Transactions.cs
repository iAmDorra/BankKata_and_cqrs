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
    }
}