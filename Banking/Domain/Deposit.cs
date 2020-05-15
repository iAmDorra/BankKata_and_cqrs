using System;

namespace Banking
{
    public class Deposit : ITransaction
    {
        private readonly uint amount;

        public Deposit(DateTime date, uint amount)
        {
            this.Date = date;
            this.amount = amount;
        }

        public DateTime Date { get; }

        public int Amount => (int)amount;
    }
}