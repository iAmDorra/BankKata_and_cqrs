using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using System;

namespace Banking.Tests
{
    [TestClass]
    public class BankingServiceTest
    {
        [TestMethod]
        public void ShouldCallTransactionsToGetBalanceWhenPrintingIt()
        {
            ITransactions transactions = Substitute.For<ITransactions>();
            var bankingService = new BankingService(transactions);

            Balance balance = bankingService.PrintBalance();

            transactions.Received().RetreiveBalance();
        }

    }
}
