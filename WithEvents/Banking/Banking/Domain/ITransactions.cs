using System;

namespace Banking
{
    public interface ITransactions
    {
        bool ContainsTransaction(int depositAmount, DateTime today);
        void Add(int depositAmount, DateTime today);
    }
}