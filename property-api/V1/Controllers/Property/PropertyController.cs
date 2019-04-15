using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.Domain;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;
using property_api.V1.UseCase.GetMultipleProperties;
using property_api.V1.Validation;

namespace property_api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/property")]
    [ApiController]
    [Produces("application/json")]
    public class PropertyController : BaseController
    {
        private IGetPropertyUseCase _getPropertyUseCase;
        private ILogger<PropertyController> _logger;
        private IGetMultiplePropertiesUseCase _getMultiplePropertiesUseCase;
        private IGetMultiplePropertiesValidator _getMultiplePropertiesValidator;

        public PropertyController(IGetPropertyUseCase getPropertyUseCase, ILogger<PropertyController> logger, IGetMultiplePropertiesUseCase getMultiplePropertiesUseCase, IGetMultiplePropertiesValidator getMultiplePropertiesValidator)
        {
            _getPropertyUseCase = getPropertyUseCase;
            _logger = logger;
            _getMultiplePropertiesUseCase = getMultiplePropertiesUseCase;
            _getMultiplePropertiesValidator = getMultiplePropertiesValidator;
        }

        // GET a property for a given property reference
        /// <summary>
        /// Returns a property for a given property reference
        /// </summary>
        /// <param name="propertyReference">The property reference for which to provide a property</param>
        /// <returns>A a property</returns>
        [HttpGet]
        [Route("{propertyReference}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetPropertyUseCase.GetPropertyByRefResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult GetByReference(string propertyReference)
        {
            _logger.LogInformation("Property information was requested for " + propertyReference);
            var result = _getPropertyUseCase.Execute(propertyReference);

            if (result.Success)
            {
                return Ok(result.Property);
            }
            return NotFound();
        }


        /// <summary>
        /// Returns a list of properties for a given property references.
        /// If propertyReferences are not found then empty list of properties is returned with 200
        /// </summary>
        /// <param name="propertyReferences"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetMultiplePropertiesUseCaseResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult GetMultipleByReference(IList<string> propertyReferences)
        {
            if (!_getMultiplePropertiesValidator.Validate(propertyReferences))
            {
                return BadRequest();
            }

            var request = new GetMultiplePropertiesUseCaseRequest
            {
                PropertyRefs = propertyReferences
            };
            var usecaseResp = _getMultiplePropertiesUseCase.Execute(request);

            return Ok(usecaseResp);
        }
    }
}
