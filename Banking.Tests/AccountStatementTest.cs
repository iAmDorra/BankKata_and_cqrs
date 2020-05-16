using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Collections.Generic;

namespace Banking.Tests
{
    [TestClass]
    public class AccountStatementTest
    {
        [TestMethod]
        public void BalanceStatementsShouldBeImmutable()
        {
            DateTime today = DateTime.Now;
            var firstStatement = new AccountStatement(today, 100, 100);
            var secondStatement = new AccountStatement(today, 100, 100);
            List<AccountStatement> statements = new List<AccountStatement>
            {
                firstStatement,
                secondStatement
            };
            var balance = new Balance(statements);
            var currentStatements = balance.GetAccountStatements();

            currentStatements.RemoveAt(0);
            Check.That(statements.Count).IsEqualTo(2);
        }
    }
}
