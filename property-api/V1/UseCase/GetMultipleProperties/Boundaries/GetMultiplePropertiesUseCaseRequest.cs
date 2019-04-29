using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace property_api.V1.UseCase.GetMultipleProperties.Boundaries
{
    public class GetMultiplePropertiesUseCaseRequest
    {
        //this constructor is needed for .net to construct this request from the controller
        public GetMultiplePropertiesUseCaseRequest()
        {
        }

        public GetMultiplePropertiesUseCaseRequest(IList<string> propertyReferences)
        {
            PropertyReferences = propertyReferences;
        }

        [Required]
        public IList<string> PropertyReferences { get; set;}
    }
}
