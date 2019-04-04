using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Models;
using property_api.V1.Domain;

namespace property_api.V1.Controllers
{
    [Route("api/v1/property")]
    [ApiController]
    [Produces("application/json")]
    public class PropertyChildrenController : BaseController
    {
        private readonly IGetPropertyChildrenUseCase _getPropertyChildrenUseCase;

        public PropertyChildrenController(IGetPropertyChildrenUseCase getPropertyChildrenUseCase)
        {
            _getPropertyChildrenUseCase = getPropertyChildrenUseCase;
        }

        [HttpGet("{propertyReference}/children")]
        [Route("{propertyReference}/children")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetPropertyUseCase.GetPropertyByRefResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult Get(string propertyReference)
        {

            
            var getPropertyChildrenRequest = new GetPropertyChildrenRequest
            {
                PropertyReference = propertyReference
            };

            var response = _getPropertyChildrenUseCase.Execute(getPropertyChildrenRequest);

            return Ok(response);
        }
    }
}
