using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyParent.Models;


namespace property_api.V1.UseCase.GetPropertyParent
{
    public interface IGetPropertyParentUseCase: IUseCaseResult<GetPropertyParentRequest, GetPropertyParentResponse>
    {
    }
}
