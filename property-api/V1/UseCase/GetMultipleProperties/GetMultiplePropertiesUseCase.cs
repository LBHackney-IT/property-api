using property_api.V1.Domain;
using property_api.V1.Gateways.GetMultipleProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace property_api.V1.UseCase.GetMultipleProperties
{
    public class GetMultiplePropertiesUseCase : IGetMultiplePropertiesUseCase
    {
        private IGetMultiplePropertiesGateway _getMultiplePropertiesGateway;

        public GetMultiplePropertiesUseCase(IGetMultiplePropertiesGateway getMultiplePropertiesGateway)
        {
            _getMultiplePropertiesGateway = getMultiplePropertiesGateway;
        }

        public GetMultiplePropertiesUseCaseResponse Execute(GetMultiplePropertiesUseCaseRequest request)
        {
            IList<string> propertyRefs = request.PropertyRefs;

            List<Property> properties = _getMultiplePropertiesGateway.GetMultiplePropertiesByPropertyListOfReferences(propertyRefs);

            return new GetMultiplePropertiesUseCaseResponse { Properties = properties };
        }
    }

}
