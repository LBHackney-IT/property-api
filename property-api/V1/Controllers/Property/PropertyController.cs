using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.Domain;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;


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

        public PropertyController(IGetPropertyUseCase getPropertyUseCase, ILogger<PropertyController> logger)
        {
            _getPropertyUseCase = getPropertyUseCase;
            _logger = logger;
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
    }
}
