using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.Boundary;
using property_api.V1.Domain;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;


namespace property_api.V1.Controllers
{
    [Route("api/v1/properties")]
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

        [HttpGet("{propertyReference}")]
        [Produces("application/json")]
        public IActionResult GetByReference(string propertyReference)
        {
            try
            {
                _logger.LogInformation("Property information was requested for " + propertyReference);
                var result = _getPropertyUseCase.Execute(propertyReference);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    DeveloperMessage = ex.Message,
                    UserMessage = "We had some issues processing your request"
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse); 
            }
        }
    }
}