using property_api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace property_api.V1.UseCase.GetMultipleProperties
{
    public interface IGetMultiplePropertiesUseCase 
    {
        GetMultiplePropertiesUseCaseResponse Execute(GetMultiplePropertiesUseCaseRequest request);
    }

    public class GetMultiplePropertiesUseCaseRequest
    {
        public IList<string> PropertyRefs { get;set;}
    }

    public class GetMultiplePropertiesUseCaseResponse
    {
        public IList<Property> Properties { get;set;}
    }
}
