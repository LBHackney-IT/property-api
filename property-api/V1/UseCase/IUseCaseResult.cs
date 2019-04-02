namespace property_api.V1.UseCase.GetPropertyChildren
{
    public interface IUseCaseResult<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}