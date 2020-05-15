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

    }
}
