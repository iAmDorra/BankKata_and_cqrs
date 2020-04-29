using System;
using System.Collections.Generic;

namespace Banking
{
    public interface ITransactions
    {
        event EventHandler AddEvent;
        bool ContainsDeposit(uint amount, DateTime today);
        bool ContainsWithdraw(uint amount, DateTime today);
        void Add(ITransaction transaction);
    }
}