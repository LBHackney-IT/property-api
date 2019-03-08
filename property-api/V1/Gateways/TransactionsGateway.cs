
using System.Collections.Generic;
using System.Linq;
using property_api.V1.Domain;
using property_api.V1.Factory;
using property_api.V1.Infrastructure;

namespace property_api.V1.Gateways
{
    public class TransactionsGateway : ITransactionsGateway
    {
        private readonly IUHContext _uhcontext;
        private readonly TransactionFactory _transactionFactory;

        public TransactionsGateway(IUHContext uhcontext)
        {
            _transactionFactory = new TransactionFactory();
            _uhcontext = uhcontext;
        }

        public List<Transaction> GetTransactionsByPropertyRef(string propertyRef)
        {
            var result = _uhcontext.UTransactions.Where(t => t.PropRef == propertyRef).ToList();
            return _transactionFactory.FromUhTransaction(result);
        }
    }
}
