using System.Collections;
using System.Collections.Generic;
using property_api.V1.Domain;

namespace property_api.V1.UseCase.GetPropertyChildren.Models
{
    public class GetPropertyChildrenResponse
    {
        public IList<Property> Children { get; set; }
    }
}
