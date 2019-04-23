using property_api.V1.Domain;
using property_api.V1.Gateways.GetMultipleProperties;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace property_api.V1.UseCase.GetMultipleProperties.Impl
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
            IList<string> propertyReferences = request.PropertyReferences;

            List<Property> properties = _getMultiplePropertiesGateway.GetMultiplePropertiesByPropertyListOfReferences(propertyReferences);

            return new GetMultiplePropertiesUseCaseResponse { Properties = properties };
        }
    }

}
