using System;

namespace Banking
{
    public class Deposit : Transaction
    {
        public override int Amount => (int)amount;

        public Deposit(DateTime today, uint amount) : base(today, amount)
        {
        }

        protected override bool Equals(Transaction transaction)
        {
            var deposit = transaction as Deposit;
            return deposit != null;
        }
    }
}