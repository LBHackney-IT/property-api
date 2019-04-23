using System;
using System.Collections.Generic;

namespace property_api.V1.Validation
{
    public interface IGetMultiplePropertiesValidator
    {
        bool Validate(IList<string> PropertyReferences);
    }
}
