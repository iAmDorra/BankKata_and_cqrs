using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using System;

namespace Banking.Tests
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void ShouldAddTheTransactionWhenDepositAnAmount()
        {
            DateTime today = DateTime.Now;
            var transactions = new Transactions();
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint depositAmount = 200;
            bankingService.Deposit(depositAmount, today);

            var transactionExists = transactions.ContainsDeposit(depositAmount, today);
            Check.That(transactionExists).IsTrue();
        }

        [TestMethod]
        public void ShouldAddTheTransactionWhenWithdrawAnAmount()
        {
            DateTime today = DateTime.Now;
            var transactions = new Transactions();
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint depositAmount = 200;
            bankingService.Withdraw(depositAmount, today);

            var transactionExists = transactions.ContainsWithdraw(depositAmount, today);
            Check.That(transactionExists).IsTrue();
        }
    }
}
