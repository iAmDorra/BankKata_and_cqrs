using System;

namespace Banking
{
    public class Withdraw : ITransaction
    {
        private readonly uint amount;

        public Withdraw(DateTime date, uint amount)
        {
            this.Date = date;
            this.amount = amount;
        }

        public DateTime Date { get; }

        public int Amount => -(int)amount;
    }
}