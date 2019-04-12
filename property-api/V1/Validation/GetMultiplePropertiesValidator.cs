using property_api.V1.Validation;
using System.Collections.Generic;
using System;

namespace property_api.V1.Validation
{
    public class GetMultiplePropertiesValidator : IGetMultiplePropertiesValidator
    {
        public bool Validate(IList<string> PropertyRefs)
        {
            
            foreach (string propRef in PropertyRefs)
            {

                if (string.IsNullOrEmpty(propRef) || string.IsNullOrWhiteSpace(propRef))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
