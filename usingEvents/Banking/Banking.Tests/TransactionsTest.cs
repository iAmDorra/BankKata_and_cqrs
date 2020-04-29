using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;

namespace Banking.Tests
{
    [TestClass]
    public class TransactionsTest
    {

        [TestMethod]
        public void ShouldReturnTheAmountOfTheTransactionWhenHavingOnlyOne()
        {
            ITransactions transactions = new Transactions();
            uint amount = 200;
            var today = DateTime.Now;
            transactions.Add(new Deposit(today, amount));

            Balance balance = transactions.GetBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(amount);
        }

        [TestMethod]
        public void ShouldReturnTheSumOfAmountsOfTransactionsWhenHavingMany()
        {
            ITransactions transactions = new Transactions();
            uint amount = 200;
            var today = DateTime.Now;
            transactions.Add(new Deposit(today, amount));
            transactions.Add(new Deposit(today, amount));

            Balance balance = transactions.GetBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(400);
        }

        [TestMethod]
        public void ShouldReturnTheSumOfAmountsOfTransactionsWhenHavingManyforDifferentDates()
        {
            ITransactions transactions = new Transactions();
            uint amount = 200;
            var today = DateTime.Now;
            transactions.Add(new Deposit(today, amount));
            transactions.Add(new Deposit(today.AddDays(1), amount));

            Balance balance = transactions.GetBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(200);
        }

        [TestMethod]
        public void ShouldReturnTheSumOfAmountsOfTransactionsWhenHavingManyforDifferentTransactionTypes()
        {
            ITransactions transactions = new Transactions();
            uint amount = 200;
            var today = DateTime.Now;
            transactions.Add(new Deposit(today, amount));
            transactions.Add(new Withdraw(today, amount));

            Balance balance = transactions.GetBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(0);
        }

        [TestMethod]
        public void ShouldRaiseAnEventWhenAddingATransaction()
        {
            var transactions = new Transactions();
            uint depositAmount = 10;
            DateTime today = default;
            int callNumber = 0;
            transactions.AddEvent += (sender, eventArgument) => { callNumber++; };

            transactions.Add(new Deposit(today, depositAmount));

            Check.That(callNumber).IsEqualTo(1);
        }
    }
}
