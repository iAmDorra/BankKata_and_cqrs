using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Banking.Tests
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void ShouldAddDepositIntoTransactions()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint depositAmount = 200;

            bankingService.Deposit(depositAmount, today);

            transactions.Received().Add(Arg.Is<ITransaction>(t => t.GetType() == typeof(Deposit)));
        }

        [TestMethod]
        public void ShouldAddWithdrawIntoTransactions()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint withdrawAmount = 200;

            bankingService.Withdraw(withdrawAmount, today);

            transactions.Received().Add(Arg.Is<ITransaction>(t => t.GetType() == typeof(Withdraw)));
        }
    }
}
