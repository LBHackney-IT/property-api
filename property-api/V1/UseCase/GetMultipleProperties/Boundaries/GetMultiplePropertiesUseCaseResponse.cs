using property_api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace property_api.V1.UseCase.GetMultipleProperties.Boundaries
{
    public class GetMultiplePropertiesUseCaseResponse
    {
        public IList<Property> Properties { get; set;}
    }
}
