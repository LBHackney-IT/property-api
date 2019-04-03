using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;
using property_api.V1.Domain;
using property_api.V1.UseCase.GetPropertyParent;
using property_api.V1.UseCase.GetPropertyParent.Models;

namespace property_api.V1.Controllers
{
    [Route("api/v1/property")]
    [ApiController]
    [Produces("application/json")]
    public class PropertyParentController : BaseController
    {
        private readonly IGetPropertyParentUseCase _getPropertyParentUseCase;
        public PropertyParentController(IGetPropertyParentUseCase getPropertyParentUseCase)
        {
            _getPropertyParentUseCase = getPropertyParentUseCase;
        }
        [HttpGet("{propertyReference}/parent")]
        [Route("{propertyReference}/parent")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetPropertyUseCase.GetPropertyByRefResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult Get(string propertyReference)
        {
            var getPropertyParentRequest = new GetPropertyParentRequest
            {
                PropertyReference = propertyReference
            };

            var response = _getPropertyParentUseCase.Execute(getPropertyParentRequest);

            return Ok(response);
        }
    }
}
