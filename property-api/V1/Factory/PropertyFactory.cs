using property_api.V1.Domain;
using property_api.V1.Infrastructure;

namespace property_api.V1.Factory
{
    public class PropertyFactory
    {
        public Property FromUHProperty(UhProperty uhproperty)
        {
            return new Property();
        }
    }
}
