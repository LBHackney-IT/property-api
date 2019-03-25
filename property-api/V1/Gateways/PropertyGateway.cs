using System.Linq;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;

namespace property_api.V1.Gateways
{

    public class PropertyGateway : IPropertyGateway
    {
        private readonly IUHContext _uhcontext;
        public PropertyGateway(IUHContext uhContext)
        {
            _uhcontext = uhContext;
        }
        public Property GetPropertyByPropertyReference(string propertyReference)
        {
            var response = _uhcontext.UhPropertys.SingleOrDefault(p => p.PropRef == propertyReference);
            if (response == null)
            {
                return null;
            }
            return new Property {
                PropRef = response.PropRef,
                Telephone = response.Telephone
            };
        }
    }
}
