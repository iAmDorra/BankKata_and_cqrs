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

        public int DailyBalance(DateTime date)
        {
            if(balance.ContainsKey(date))
                return balance[date];

            return 0;
        }
    }
}