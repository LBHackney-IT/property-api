using System;
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
        public Property GetPropertyByPropertyReference(string PropertyReference)
        {
            var intReference = Int32.Parse(PropertyReference);
            // TODO change the startswith
            var response = _uhcontext.UHPropertys.Where(p => p.PropRef == intReference).FirstOrDefault<UHProperty>();
            if (response == null)
            {
                return null;
            };
            return new Property{
                PropRef = response.PropRef,
                Telephone = response.Telephone
            };
        }
    }
}