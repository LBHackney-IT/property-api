using property_api.V1.Validation;
using System.Collections.Generic;
using System;

namespace property_api.V1.Validation
{
    public class GetMultiplePropertiesValidator : IGetMultiplePropertiesValidator
    {
        public bool Validate(IList<string> PropertyReferences)
        {
            if(PropertyReferences == null)
            {
                return false;
            }

            foreach (string propertyReference in PropertyReferences)
            {
                if (string.IsNullOrEmpty(propertyReference) || string.IsNullOrWhiteSpace(propertyReference))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
