using FluentValidation.Results;
using JenkinsBuildStats.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JenkinsBuildStats.API.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorDTO))]
    public class BaseApiController : ControllerBase
    {
        protected readonly ILogger<BaseApiController> _logger;

        protected BaseApiController(ILogger<BaseApiController> logger)
        {
            _logger = logger;
        }

        protected IActionResult BadRequest(IReadOnlyCollection<ValidationFailure> errors)
        {
            var response = new BadRequestDTO
            {
                ErrorMessages = errors.Select(x => x.ErrorMessage)
            };

            return BadRequest(response);
        }

        protected IActionResult InternalServerError(Exception exception)
        {
            _logger.LogError($"Error occured: {exception}");
            return StatusCode(500, new InternalServerErrorDTO("There was an error during request. Please try again later"));
        }
    }
}
