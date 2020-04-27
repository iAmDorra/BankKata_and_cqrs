using System;

namespace Banking
{
    public interface ITransaction
    {
        int Amount { get; }
        DateTime Date { get; }
    }
}