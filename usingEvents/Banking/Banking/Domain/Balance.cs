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

        internal void UpdateDailyAmount(DateTime date, int amount)
        {
            if (balance.ContainsKey(date))
            {
                balance[date] += amount;
            }
            else
            {
                balance[date] = amount;
            }
        }
    }
}