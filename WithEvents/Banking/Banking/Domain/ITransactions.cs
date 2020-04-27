using System;

namespace Banking
{
    public interface ITransactions
    {
        bool ContainsDeposit(int depositAmount, DateTime today);
        void Add(ITransaction transaction);
    }
}