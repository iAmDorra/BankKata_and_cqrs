using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;

namespace Banking.Tests
{
    [TestClass]
    public class DailyBalanceAcceptanceTest
    {
        [TestMethod]
        public void ShouldCalculateTheAmountOfTheDailyBalanceFromDepositsAndWithdraws()
        {
            DateTime today = DateTime.Now;
            Transactions transactions = new Transactions();
            IBalanceRetriever balanceRetriever = new BalanceRetriever(transactions);
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint depositAmount = 200;
            bankingService.Deposit(depositAmount, today);
            uint withDrawAmount = 100;
            bankingService.Withdraw(withDrawAmount, today);
            bankingService.Deposit(depositAmount, today);

            Balance balance = bankingService.PrintBalance();

            int todayBalance = 300;
            Check.That(balance.DailyBalance(today)).IsEqualTo(todayBalance);
        }

        [TestMethod]
        public void ShouldReturnZeroWhenThereIsNoTransactionForTheRelatedDay()
        {
            DateTime today = DateTime.Now;
            Transactions transactions = new Transactions();
            IBalanceRetriever balanceRetriever = new BalanceRetriever(transactions);
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint depositAmount = 200;
            bankingService.Deposit(depositAmount, today);
            uint withDrawAmount = 100;
            bankingService.Withdraw(withDrawAmount, today);
            bankingService.Deposit(depositAmount, today);

            Balance balance = bankingService.PrintBalance();

            int tomorrowBalance = 0;
            DateTime tomorow = today.AddDays(1);
            Check.That(balance.DailyBalance(tomorow)).IsEqualTo(tomorrowBalance);
        }
    }
}
