using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Tests
{
    [TestClass]
    public class BankingServiceTest
    {
        [TestMethod]
        public void ShouldReturnTheAmountOfTheTransactionWhenHavingOnlyOne()
        {
            ITransactions transactions = Substitute.For<ITransactions>();
            uint amount = 200;
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

        [TestMethod]
        public void ShouldReturnTheSumOfAmountsOfTransactionsWhenHavingMany()
        {
            ITransactions transactions = Substitute.For<ITransactions>();
            uint amount = 200;
            var today = DateTime.Now;
            List<ITransaction> transactionCollection = new List<ITransaction>
            {
                new Deposit(today, amount),
                new Deposit(today, amount),
            };
            transactions.GetAll().Returns(transactionCollection);
            var bankingService = new BankingService(transactions);

            Balance balance = bankingService.PrintBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(400);
        }

        [TestMethod]
        public void ShouldReturnTheSumOfAmountsOfTransactionsWhenHavingManyforDifferentDates()
        {
            ITransactions transactions = Substitute.For<ITransactions>();
            uint amount = 200;
            var today = DateTime.Now;
            List<ITransaction> transactionCollection = new List<ITransaction>
            {
                new Deposit(today, amount),
                new Deposit(today.AddDays(1), amount),
            };
            transactions.GetAll().Returns(transactionCollection);
            var bankingService = new BankingService(transactions);

            Balance balance = bankingService.PrintBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(200);
        }

        [TestMethod]
        public void ShouldReturnTheSumOfAmountsOfTransactionsWhenHavingManyforDifferentTransactionTypes()
        {
            ITransactions transactions = Substitute.For<ITransactions>();
            uint amount = 200;
            var today = DateTime.Now;
            List<ITransaction> transactionCollection = new List<ITransaction>
            {
                new Deposit(today, amount),
                new Withdraw(today, amount),
            };
            transactions.GetAll().Returns(transactionCollection);
            var bankingService = new BankingService(transactions);

            Balance balance = bankingService.PrintBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(0);
        }
    }
}
