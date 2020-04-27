using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
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
            var bankingService = new BankingService(transactions);
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
            var bankingService = new BankingService(transactions);
            uint depositAmount = 200;
            bankingService.Withdraw(depositAmount, today);

            var transactionExists = transactions.ContainsWithdraw(depositAmount, today);
            Check.That(transactionExists).IsTrue();
        }
    }
}
