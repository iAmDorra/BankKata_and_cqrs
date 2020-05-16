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

        public List<ITransaction> GetAll()
        {
            return new List<ITransaction>(transactions);
        }
    }
}