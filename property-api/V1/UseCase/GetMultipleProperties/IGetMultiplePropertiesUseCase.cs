using property_api.V1.UseCase.GetMultipleProperties.Boundaries;

namespace property_api.V1.UseCase.GetMultipleProperties
{
    public interface IGetMultiplePropertiesUseCase
    {
        GetMultiplePropertiesUseCaseResponse Execute(GetMultiplePropertiesUseCaseRequest request);
    }
}
