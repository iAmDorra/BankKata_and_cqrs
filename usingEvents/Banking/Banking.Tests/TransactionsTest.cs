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

        [TestMethod]
        public void ShouldRaiseAnEventWithTheAddedTransactionAndTheSenderWhenAddingATransaction()
        {
            var transactions = new Transactions();
            object eventSender = null;
            EventArgs eventArgs = null;
            transactions.AddEvent += (sender, eventArgument) =>
            {
                eventSender = sender;
                eventArgs = eventArgument;
            };

            uint depositAmount = 10;
            DateTime today = default;
            Deposit deposit = new Deposit(today, depositAmount);
            transactions.Add(deposit);

            Check.That(eventSender).IsEqualTo(transactions);
            Check.That(eventArgs).IsInstanceOf<TransactionEventArgs>();
            var transactionEventArgs = eventArgs as TransactionEventArgs;
            Check.That(transactionEventArgs.Transaction).IsEqualTo(deposit);
        }

        [TestMethod]
        public void ShouldHandleTheAddEventToCalculateTheBalanceWhenAddingADeposit()
        {
            ITransactions transactions = new Transactions();

            uint depositAmount = 10;
            DateTime today = default;
            Deposit deposit = new Deposit(today, depositAmount);
            transactions.Add(deposit);

            Balance balance = transactions.RetreiveBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(depositAmount);
        }

        [TestMethod]
        public void ShouldHandleTheAddEventToCalculateTheBalanceWhenAddingTwoDeposit()
        {
            ITransactions transactions = new Transactions();

            uint depositAmount = 10;
            DateTime today = default;
            Deposit deposit = new Deposit(today, depositAmount);
            transactions.Add(deposit);
            transactions.Add(deposit);

            Balance balance = transactions.RetreiveBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(20);
        }

        [TestMethod]
        public void ShouldHandleTheAddEventToCalculateTheBalanceWhenAddingTwoDepositInDifferentDates()
        {
            ITransactions transactions = new Transactions();

            uint depositAmount = 10;
            DateTime today = default;
            transactions.Add(new Deposit(today, depositAmount));
            transactions.Add(new Deposit(today.AddDays(1), depositAmount));

            Balance balance = transactions.RetreiveBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(10);
        }

        [TestMethod]
        public void ShouldHandleTheAddEventToCalculateTheBalanceWhenAddingOneDepositAndOneWithdrawOnSameDate()
        {
            ITransactions transactions = new Transactions();

            uint depositAmount = 10;
            DateTime today = default;
            transactions.Add(new Deposit(today, depositAmount));
            transactions.Add(new Withdraw(today, depositAmount));

            Balance balance = transactions.RetreiveBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(0);
        }

        [TestMethod]
        public void ShouldHandleTheAddEventToCalculateTheBalanceWhenAddingOneDepositAndOneWithdrawOnDifferentDates()
        {
            ITransactions transactions = new Transactions();

            uint depositAmount = 10;
            DateTime today = default;
            transactions.Add(new Deposit(today, depositAmount));
            transactions.Add(new Withdraw(today.AddDays(1), depositAmount));

            Balance balance = transactions.RetreiveBalance();

            Check.That(balance.DailyBalance(today)).IsEqualTo(10);
        }
    }
}
