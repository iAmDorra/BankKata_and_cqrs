using System;
using System.Collections.Generic;

namespace Banking
{
    public interface IBalanceRetriever
    {
        List<AccountStatement> GetStatements();
    }
}