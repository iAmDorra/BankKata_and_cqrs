using System;
using System.Collections.Generic;

namespace Banking
{
    public interface ITransactions
    {
        bool ContainsDeposit(uint amount, DateTime today);
        bool ContainsWithdraw(uint amount, DateTime today);
        void Add(ITransaction transaction);
        List<ITransaction> GetAll();
    }
}