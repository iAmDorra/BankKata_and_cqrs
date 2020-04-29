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
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);

            Balance balance = bankingService.PrintBalance();

            balanceRetriever.Received().RetrieveBalance();
        }

    }
}
