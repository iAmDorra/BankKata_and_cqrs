using System.Collections.Generic;

namespace Banking
{
    public interface ITransactions
    {
        void Add(ITransaction transaction);
        List<ITransaction> GetAll();
    }
}