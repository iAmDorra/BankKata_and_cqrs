using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Banking.Tests
{
    [TestClass]
    public class BankingServiceTest
    {
        [TestMethod]
        public void ShouldReturnTheAmountOfTheTransactionWhenHavingOnlyOne()
        {
            ITransactions transactions = Substitute.For<ITransactions>();
            int amount = 200;
            var today = DateTime.Now;
            List<ITransaction> transactionCollection = new List<ITransaction>
            {
                new Deposit(today, amount)
            };
            transactions.GetAll().Returns(transactionCollection);
            var bankingService = new BankingService(transactions);
            
            Balance balance = bankingService.PrintBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(amount);
        }
    }
}
