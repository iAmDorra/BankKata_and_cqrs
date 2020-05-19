using Banking.Application;
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
        public void ShouldAddDepositIntoTransactions()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint depositAmount = 200;

            bankingService.Deposit(depositAmount, today);

            transactions.Received().Add(Arg.Is<ITransaction>(t => t.GetType() == typeof(Deposit)));
        }

        [TestMethod]
        public void ShouldAddWithdrawIntoTransactions()
        {
            DateTime today = DateTime.Now;
            ITransactions transactions = Substitute.For<ITransactions>();
            IBalanceRetriever balanceRetriever = Substitute.For<IBalanceRetriever>();
            var bankingService = new BankingService(transactions, balanceRetriever);
            uint withdrawAmount = 200;

            bankingService.Withdraw(withdrawAmount, today);

            transactions.Received().Add(Arg.Is<ITransaction>(t => t.GetType() == typeof(Withdraw)));
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
        public void ShouldAddTheAmountOfDepositToTheBalanceValue()
        {
            DateTime today = DateTime.Now;
            uint amount = 200;
            var deposit = new Deposit(today, amount);
            int balance = 0;
            var newBalanceValue =  deposit.AddBalanceToAmount(balance);
            Check.That(newBalanceValue).IsEqualTo(balance + amount);
        }

        [TestMethod]
        public void ShouldAddTheAmountOfWithdrawToTheBalanceValue()
        {
            DateTime today = DateTime.Now;
            uint amount = 200;
            var deposit = new Withdraw(today, amount);
            int balance = 0;
            var newBalanceValue = deposit.AddBalanceToAmount(balance);
            Check.That(newBalanceValue).IsEqualTo(balance - amount);
        }
    }
}
