using property_api.V1.Domain;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace property_api.V1.UseCase.GetMultipleProperties.Boundaries
{
    public class GetMultiplePropertiesUseCaseResponse
    {
        public GetMultiplePropertiesUseCaseResponse(IList<Property> properties)
        {
            ValidRequest = true;
            Errors = new List<string>();
            Properties = properties;
        }

        public GetMultiplePropertiesUseCaseResponse(ValidationResult validationResult)
        {
            Properties = new List<Property>();
            ValidRequest = validationResult.IsValid;
            Errors = validationResult.Errors.Select(t => t.ToString()).ToArray();
        }

        public bool ValidRequest { get; set; }
        public IList<string> Errors { get; set; }
        public IList<Property> Properties { get; set;}
    }
}
