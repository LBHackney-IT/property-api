using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.UseCase;

namespace property_api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/healthcheck")]
    [ApiController]
    [Produces("application/json")]
    public class HealthCheckController : BaseController
    {
        /// <summary>
        /// Health Check
        /// </summary>
        /// <returns>Return status 200 for successful request</returns>
        [HttpGet]
        [Route("ping")]
        [ProducesResponseType(typeof(Dictionary<string, bool>), 200)]
        public IActionResult HealthCheck()
        {
            var result = new Dictionary<string, bool> {{"success", true}};

            return Ok(result);
        }
        /// <summary>
        /// Error Check
        /// </summary>
        [HttpGet]
        [Route("error")]
        public void ThrowError()
        {
            ThrowOpsErrorUsecase.Execute();
        }

    }
}