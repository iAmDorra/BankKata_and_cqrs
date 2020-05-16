using Banking.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;

namespace Banking.Tests
{
    [TestClass]
    public class PrintBalanceAcceptanceTest
    {
        [TestMethod]
        public void ShouldReturnAccountStatementsWithDepositsAndWithdrawsWhenPrintingBalance()
        {
            DateTime today = DateTime.Now;
            var transactions = new Transactions();
            var bankingService = new BankingService(transactions);
            uint depositAmount = 200;
            bankingService.Deposit(depositAmount, today);
            uint withDrawAmount = 100;
            bankingService.Withdraw(withDrawAmount, today.AddDays(1));
            bankingService.Deposit(depositAmount, today.AddDays(2));

            Balance balance = bankingService.PrintBalance();

            var expectedStatements = new List<AccountStatement>
            {
                new AccountStatement(today.AddDays(2), 200, 300),
                new AccountStatement(today.AddDays(1), -100, 100),
                new AccountStatement(today, 200, 200)
            };
            Check.That(balance.GetAccountStatements()).IsEqualTo(expectedStatements);
        }
    }
}
