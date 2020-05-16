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
        public void ShouldReturnOneStatementWhenHavingOneDepositTransaction()
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

        [TestMethod]
        public void ShouldReturnOneStatementWhenHavingOneWithdrawTransaction()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>
            {
                new Withdraw(today, 100)
            };
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements())
                .ContainsExactly(new AccountStatement(today, -100, -100));
        }

        [TestMethod]
        public void ShouldReturnTwoStatementsWithCalculatedBalanceWhenHavingtwoDeposits()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>
             {
                new Deposit(today, 100),
                new Deposit(today, 100)
            };
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements())
                            .ContainsExactly(
            new AccountStatement(today, 100, 100),
            new AccountStatement(today, 100, 200));
        }

        [TestMethod]
        public void ShouldReturnTwoStatementsWithCalculatedBalanceWhenHavingADepositAndAWithdraw()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>
            {
                new Deposit(today, 100),
                new Withdraw(today, 100)
            };
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements())
                .ContainsExactly(
                new AccountStatement(today, 100, 100),
                new AccountStatement(today, -100, 0));
        }

        [TestMethod]
        public void ShouldReturnTwoStatementsWithNegativeAmountsAndCalculatedBalanceWhenHavingTwoWithdraw()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>
            {
                new Withdraw(today, 100),
                new Withdraw(today, 100)
            };
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements())
                .ContainsExactly(
                new AccountStatement(today, -100, -100),
                new AccountStatement(today, -100, -200));
        }

        [TestMethod]
        public void ShouldReturnStatementsInDescendingDateOrderWhenPrintingBalance()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<ITransaction> noTransactions = new List<ITransaction>
            {
                new Deposit(today, 200),
                new Withdraw(today.AddDays(1), 100),
                new Deposit(today.AddDays(2), 100),
            };
            transactions.GetAll().Returns(noTransactions);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            var expectedStatements = new List<AccountStatement>
            {
                new AccountStatement(today.AddDays(2), 100, 200),
                new AccountStatement(today.AddDays(1), -100, 100),
                new AccountStatement(today, 200, 200)
            };
            Check.That(balance.GetAccountStatements()).IsEqualTo(expectedStatements);
        }
    }
}
