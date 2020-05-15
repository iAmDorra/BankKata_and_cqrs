using System.Collections.Generic;

namespace Banking
{
    public class Balance
    {
        private List<AccountStatement> statements;

        public Balance(List<AccountStatement> statements)
        {
            this.statements = statements;
        }

        public List<AccountStatement> GetAccountStatements()
        {
            return statements;
        }
    }
}