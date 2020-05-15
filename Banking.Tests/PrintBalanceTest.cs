using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Banking.Tests
{
    [TestClass]
    public class PrintBalanceTest
    {
        [TestMethod]
        public void ShouldReturnNoStatementWhenHavingNoTransaction()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>();
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements()).IsEmpty();
        }

        [TestMethod]
        public void ShouldReturnOneStatementWhenHavingOneTransaction()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>
            {
                new Deposit(today, 100)
            };
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements())
                .ContainsExactly(new AccountStatement(today, 100, 100));
        }
    }
}
