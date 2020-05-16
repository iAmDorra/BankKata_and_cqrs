using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class BankingService
    {
        private ITransactions transactions;
        private readonly IBalanceRetriever balanceRetriever;

        public BankingService(ITransactions transactions, IBalanceRetriever balanceRetriever)
        {
            this.transactions = transactions;
            this.balanceRetriever = balanceRetriever;
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
            List<AccountStatement> statements = this.balanceRetriever.GetStatements();

            return new Balance(statements);
        }
    }
}