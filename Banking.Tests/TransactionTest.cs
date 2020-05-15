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
            var bankingService = new BankingService(transactions);
            uint depositAmount = 200;

            bankingService.Deposit(depositAmount, today);

            transactions.Received().Add(Arg.Is<ITransaction>(t => t.GetType() == typeof(Deposit)));
        }

        [TestMethod]
        public void ShouldAddWithdrawIntoTransactions()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            var bankingService = new BankingService(transactions);
            uint withdrawAmount = 200;

            bankingService.Withdraw(withdrawAmount, today);

            transactions.Received().Add(Arg.Is<ITransaction>(t => t.GetType() == typeof(Withdraw)));
        }      
    }
}
