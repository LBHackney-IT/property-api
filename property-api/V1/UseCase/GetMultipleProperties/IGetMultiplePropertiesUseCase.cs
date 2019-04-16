using property_api.V1.Domain;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;
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
}
