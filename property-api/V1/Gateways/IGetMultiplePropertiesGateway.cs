using property_api.V1.Domain;
using System.Collections.Generic;

namespace property_api.V1.Gateways.GetMultipleProperties
{
    public interface IGetMultiplePropertiesGateway
    {
        List<Property> GetMultiplePropertiesByPropertyListOfReferences(IList<string> propertyRefs);
    }
}
