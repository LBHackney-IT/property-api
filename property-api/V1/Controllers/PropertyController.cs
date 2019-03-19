using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using property_api.V1.UseCase;

namespace property_api.V1.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces("application/json")]
    public class PropertyController : BaseController
    {
       private IGetPropertyUseCase _getPropertyUseCase;

        public PropertyController(IGetPropertyUseCase getPropertyUseCase)
        {
            _getPropertyUseCase = getPropertyUseCase;
        }

        [HttpGet]
        [Route("property")]
        [Produces("application/json")]
        public JsonResult GetByReference(string propertyReference)
        {
            var result = new Dictionary<string, bool> {{"success", true}};

            return Json(result);
        }
    }
}