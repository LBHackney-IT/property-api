using System;
using property_api.V1.Gateways;
using property_api.V1.UseCase.GetPropertyChildren.Models;

namespace property_api.V1.UseCase.GetPropertyChildren.Impl
{
    public class GetPropertyChildrenUseCase : IGetPropertyChildrenUseCase
    {
        private readonly IGetPropertyChildrenGateway _gateway;

        public GetPropertyChildrenUseCase(IGetPropertyChildrenGateway gateway)
        {
            _gateway = gateway;
        }

        public GetPropertyChildrenResponse Execute(GetPropertyChildrenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var response = _gateway.GetPropertyChild(request.PropertyReference);

            return new GetPropertyChildrenResponse
            {
                Children = response
            };
        }
    }
}
