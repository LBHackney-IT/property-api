using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.Domain;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;
using property_api.V1.UseCase.GetMultipleProperties;
using property_api.V1.Validation;
using System.Linq;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;

namespace property_api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/properties")]
    [ApiController]
    [Produces("application/json")]
    public class PropertyController : BaseController
    {
        private IGetPropertyUseCase _getPropertyUseCase;
        private ILogger<PropertyController> _logger;
        private IGetMultiplePropertiesUseCase _getMultiplePropertiesUseCase;
        private GetMultiplePropertiesValidator _getMultiplePropertiesValidator;

        public PropertyController(IGetPropertyUseCase getPropertyUseCase, ILogger<PropertyController> logger, IGetMultiplePropertiesUseCase getMultiplePropertiesUseCase)
        {
            _getPropertyUseCase = getPropertyUseCase;
            _logger = logger;
            _getMultiplePropertiesUseCase = getMultiplePropertiesUseCase;
            _getMultiplePropertiesValidator = new GetMultiplePropertiesValidator();
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
        /// Up to 200 properties can be requested at once
        /// If propertyReferences are not found then empty list of properties is returned with 200
        /// </summary>
        /// <param name="propertyReferencesRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetMultiplePropertiesUseCaseResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult GetMultipleByReference([FromQuery]GetMultiplePropertiesUseCaseRequest propertyReferencesRequest)
        {
            _logger.LogInformation("Multiple Property information was requested for " + propertyReferencesRequest.PropertyReferences?.Select(s => s + " ").ToList());

            var validationResult = _getMultiplePropertiesValidator.Validate(propertyReferencesRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(new GetMultiplePropertiesUseCaseResponse(validationResult));
            }
            var useCaseResponse = _getMultiplePropertiesUseCase.Execute(propertyReferencesRequest);

            return Ok(useCaseResponse);
        }
    }
}
