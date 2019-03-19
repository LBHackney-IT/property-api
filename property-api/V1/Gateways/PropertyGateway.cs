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
            uhContext = _uhcontext;
        }
        public Property GetPropertyByPropertyReference()
        {
            return null; 
        }
    }
}