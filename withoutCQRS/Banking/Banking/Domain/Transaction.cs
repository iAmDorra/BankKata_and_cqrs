using System;

namespace Banking
{
    public abstract class Transaction : ITransaction
    {
        protected readonly DateTime today;
        protected readonly uint amount;


        public DateTime Date => today;

        public abstract int Amount { get; }

        public Transaction(DateTime today, uint amount)
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

            return Equals(transaction);
        }

        protected abstract bool Equals(Transaction transaction);

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}