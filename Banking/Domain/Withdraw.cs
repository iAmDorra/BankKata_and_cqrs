using System;

namespace Banking
{
    public class Withdraw : ITransaction
    {
        public Withdraw(DateTime date, uint amount)
        {
        }

        public DateTime Date => throw new NotImplementedException();

        public int Amount => throw new NotImplementedException();
    }
}