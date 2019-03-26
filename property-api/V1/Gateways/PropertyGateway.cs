using System.Linq;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;
using property_api.V1.Factory;

namespace property_api.V1.Gateways
{

    public class PropertyGateway : IPropertyGateway
    {
        private readonly IUHContext _uhContext;
        private readonly PropertyFactory _factory;

        public PropertyGateway(IUHContext uhContext, PropertyFactory factory)
        {
            _uhContext = uhContext;
            _factory = factory;
        }
        public Property GetPropertyByPropertyReference(string propertyReference)
        {
            var response = _uhContext.UhPropertys.SingleOrDefault(p => p.PropRef == propertyReference);
            if (response == null)
            {
                return null;
            }
            return _factory.FromUHProperty(response);
        }
    }
}
