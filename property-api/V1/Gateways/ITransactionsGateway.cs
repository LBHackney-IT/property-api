using System.Collections.Generic;
using property_api.V1.Domain;

namespace property_api.V1.Gateways
{
    public interface ITransactionsGateway
    {
        List<Transaction> GetTransactionsByPropertyRef(string propertyRef);
    }
}
