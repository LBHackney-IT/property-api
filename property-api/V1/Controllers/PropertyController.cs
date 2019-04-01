using Microsoft.AspNetCore.Mvc;
using property_api.V1.UseCase;
using Microsoft.Extensions.Logging;


namespace property_api.V1.Controllers
{
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

        [HttpGet("{propertyReference}")]
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
