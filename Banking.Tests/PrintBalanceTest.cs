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
            List<AccountStatement> noStatements = new List<AccountStatement>();
            transactions.GetStatements().Returns(noStatements);
            var bankingService = new BankingService(transactions);

            var balance = bankingService.PrintBalance();

            Check.That(balance.GetAccountStatements()).IsEmpty();
        }

        [TestMethod]
        public void ShouldReturnOneStatementWhenHavingOneDepositTransaction()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            List<AccountStatement> statements = new List<AccountStatement>
            {
                new AccountStatement(today, 100, 100)
            };
            transactions.GetStatements().Returns(statements);
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
            List<AccountStatement> statements = new List<AccountStatement>
            {
                new AccountStatement(today, -100, -100)
            };
            transactions.GetStatements().Returns(statements);
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
            List<AccountStatement> statements = new List<AccountStatement>
            {
                new AccountStatement(today, 100, 100),
                new AccountStatement(today, 100, 200)
            };
            transactions.GetStatements().Returns(statements);
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
            List<AccountStatement> statements = new List<AccountStatement>
            {
                new AccountStatement(today, 100, 100),
                new AccountStatement(today, -100, 0)
            };
            transactions.GetStatements().Returns(statements);
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
            List<AccountStatement> statements = new List<AccountStatement>
            {
                new AccountStatement(today, -100, -100),
                new AccountStatement(today, -100, -200)
            };
            transactions.GetStatements().Returns(statements);
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
            List<AccountStatement> statements = new List<AccountStatement>
            {
                new AccountStatement(today.AddDays(2), 100, 200),
                new AccountStatement(today.AddDays(1), -100, 100),
                new AccountStatement(today, 200, 200)
            };
            transactions.GetStatements().Returns(statements);
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
