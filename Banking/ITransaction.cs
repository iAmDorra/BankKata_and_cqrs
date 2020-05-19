using System;

namespace Banking
{
    public interface ITransaction
    {
        DateTime Date { get; }
        int Amount { get; }

        int AddBalanceToAmount(int balance);
    }
}
