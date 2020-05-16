using System.Collections.Generic;

namespace Banking
{
    public interface ITransactions
    {
        void Add(ITransaction transaction);
        IEnumerable<ITransaction> GetAll();
    }
}