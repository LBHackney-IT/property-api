using property_api.V1.Domain;

namespace property_api.V1.Gateways
{
    public interface IPropertyGateway
    {
        Property GetPropertyByPropertyReference();
    }
}