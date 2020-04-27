using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;

namespace Banking.Tests
{
    [TestClass]
    public class DepositTest
    {
        [TestMethod]
        public void ShouldAddTheTransactionWhenDepositAndAmount()
        {
            DateTime today = DateTime.Now;
            var transactions = new Transactions();
            var bankingService = new BankingService(transactions);
            int depositAmount = 200;
            bankingService.Deposit(depositAmount, today);

            var transactionExists = transactions.ContainsTransaction(depositAmount, today);
            Check.That(transactionExists).IsTrue();
        }
    }
}
