using JenkinsBuildStats.API.DTO;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JenkinsBuildStats.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            _logger.LogError($"Error occured at {exceptionHandlerFeature.Endpoint}: {exceptionHandlerFeature.Error}");

            return StatusCode(500, new InternalServerErrorDTO("Unexpected error occured"));
        }
    }
}
