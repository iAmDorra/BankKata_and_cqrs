using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class BankingService
    {
        private ITransactions transactions;

        public BankingService(ITransactions transactions)
        {
            this.transactions = transactions;
        }

        public void Deposit(uint depositAmount, DateTime today)
        {
            var deposit = new Deposit(today, depositAmount);
            transactions.Add(deposit);
        }

        public void Withdraw(uint withDrawAmount, DateTime dateTime)
        {
            var withdraw = new Withdraw(dateTime, withDrawAmount);
            transactions.Add(withdraw);
        }

        public Balance PrintBalance()
        {
            var transactions = this.transactions.GetAll();
            var statements = new List<AccountStatement>();

            var balance = 0;
            foreach (var transaction in transactions)
            {
                if (transaction != null)
                {
                    balance += transaction.Amount;
                    statements.Add(new AccountStatement(transaction.Date, transaction.Amount, balance));
                }
            }

            return new Balance(statements);
        }
    }
}