using System;
using System.Collections.Generic;

namespace Banking
{
    public class Balance
    {
        private Dictionary<DateTime, int> balance;

        public Balance(Dictionary<DateTime, int> balance)
        {
            this.balance = balance;
        }

        public int DailyBalance(DateTime today)
        {
            return balance[today];
        }
    }
}