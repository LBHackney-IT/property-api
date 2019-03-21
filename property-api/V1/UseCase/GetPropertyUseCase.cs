using System;
using property_api.V1.Domain;
using property_api.V1.Gateways;

namespace property_api.V1.UseCase
{
    public class GetPropertyUseCase : IGetPropertyUseCase
    {
        private IPropertyGateway _gateway;
        public GetPropertyUseCase(IPropertyGateway gateway)
        {
            _gateway = gateway;
        }
        public Property Execute(string propertyReference)
        {
            var response = _gateway.GetPropertyByPropertyReference("foo");
            return response;
        }
    }
}
