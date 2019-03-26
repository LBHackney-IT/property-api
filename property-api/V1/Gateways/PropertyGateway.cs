using System.Linq;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;
using property_api.V1.Factory;
using AutoMapper;

namespace property_api.V1.Gateways
{

    public class PropertyGateway : IPropertyGateway
    {
        private readonly IUHContext _uhcontext;
        private readonly PropertyFactory _factory;

        public PropertyGateway(IUHContext uhContext, PropertyFactory factory)
        {
            _uhcontext = uhContext;
            _factory = factory;
        }
        public Property GetPropertyByPropertyReference(string propertyReference)
        {
            var response = _uhcontext.UhPropertys.SingleOrDefault(p => p.PropRef == propertyReference);
            if (response == null)
            {
                return null;
            }
            return _factory.FromUHProperty(response);
        }
    }
}
