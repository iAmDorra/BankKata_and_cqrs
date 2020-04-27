using System;

namespace Banking
{
    internal class Transaction
    {
        private DateTime today;
        private int amount;

        public Transaction(DateTime today, int amount)
        {
            this.today = today;
            this.amount = amount;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;
            if (transaction == null
                || GetType() != obj.GetType())
            {
                return false;
            }

            if (transaction.today != this.today
                && transaction.amount != this.amount)
            {
                return false;
            }

            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}