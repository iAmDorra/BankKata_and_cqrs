using System;

namespace Banking
{
    public class Withdraw : Transaction
    {
        public override int Amount => -((int)amount);

        public Withdraw(DateTime today, uint amount) : base(today, amount)
        {
        }

        protected override bool Equals(Transaction transaction)
        {
            var withdraw = transaction as Withdraw;
            return withdraw != null;
        }
    }
}