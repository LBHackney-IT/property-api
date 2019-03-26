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
        public GetPropertyByRefResponse Execute(string propertyReference)
        {
            var response = _gateway.GetPropertyByPropertyReference(propertyReference);

            return new GetPropertyByRefResponse(response);
        }

        public class GetPropertyByRefResponse
        {
            public readonly bool Success;
            public readonly Property Property;

            public GetPropertyByRefResponse(Property property)
            {
                if (property != null)
                {
                    Success = true;
                }
                Property = property;
            }

        }
    }
}
