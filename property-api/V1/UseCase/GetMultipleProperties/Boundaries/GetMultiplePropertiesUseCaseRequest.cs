using property_api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace property_api.V1.UseCase.GetMultipleProperties.Boundaries
{
    public class GetMultiplePropertiesUseCaseRequest
    {
        public IList<string> PropertyRefs { get;set;}
    }
}
