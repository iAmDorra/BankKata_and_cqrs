using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Balance
    {
        private IEnumerable<AccountStatement> statements;

        public Balance(IEnumerable<AccountStatement> statements)
        {
            this.statements = statements;
        }

        public List<AccountStatement> GetAccountStatements()
        {
            return new List<AccountStatement>(statements.OrderByDescending(t => t.Date));
        }
    }
}