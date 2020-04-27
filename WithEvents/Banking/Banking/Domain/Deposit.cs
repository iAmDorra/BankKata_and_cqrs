using System;

namespace Banking
{
    internal class Deposit : Transaction
    {
        public Deposit(DateTime today, int amount) : base(today, amount)
        {
        }

        protected override bool Equals(Transaction transaction)
        {
            var deposit = transaction as Deposit;
            return deposit != null;
        }
    }
}