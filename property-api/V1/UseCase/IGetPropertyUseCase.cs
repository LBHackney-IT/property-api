using property_api.V1.Domain;

namespace property_api.V1.UseCase
{
    public interface IGetPropertyUseCase
    {
        Property Execute(string propertyReference);
    }
}

