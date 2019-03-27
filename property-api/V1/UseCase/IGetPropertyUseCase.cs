namespace property_api.V1.UseCase
{
    public interface IGetPropertyUseCase
    {
        GetPropertyUseCase.GetPropertyByRefResponse Execute(string propertyReference);
    }
}

