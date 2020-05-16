using System;

namespace Banking
{
    public struct AccountStatement
    {
        private DateTime date;
        private int amount;
        private int balance;

        public AccountStatement(DateTime date, int amount, int balance)
        {
            this.date = date;
            this.amount = amount;
            this.balance = balance;
        }

        public DateTime Date => date;
    }
}