using System;

namespace Banking
{
    internal class Withdraw : Transaction
    {
        public Withdraw(DateTime today, int amount) : base(today, amount)
        {
        }

        protected override bool Equals(Transaction transaction)
        {
            var withdraw = transaction as Withdraw;
            return withdraw != null;
        }
    }
}