﻿namespace property_api.V1.Boundary
{
    public interface IListTransactions
    {
        ListTransactionsResponse Execute(ListTransactionsRequest propertyRefrence);
    }
}