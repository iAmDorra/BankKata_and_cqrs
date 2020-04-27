using System;
using System.Collections.Generic;

namespace Banking
{
    public interface ITransactions
    {
        bool ContainsDeposit(int depositAmount, DateTime today);
        void Add(ITransaction transaction);
        List<ITransaction> GetAll();
    }
}