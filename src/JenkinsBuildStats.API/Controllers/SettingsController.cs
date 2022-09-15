using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JenkinsBuildStats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SettingsController(IMapper mapper,
            IMediator mediator,
            ILogger<SettingsController> logger) : base(logger)
        {
            _mapper = mapper;
            _mediator = mediator;  
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Settings", Description = "Get configuration settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SettingsDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var getSettingsRequest = new GetSettingsRequest();
            var getSettingsResponse = await _mediator.Send(getSettingsRequest, cancellationToken);

            return getSettingsResponse
                .Match((setting) =>
                {
                    var dto = _mapper.Map<SettingsDTO>(setting);
                    return Ok(dto);
                },
                (noSettings) =>
                {
                    return NotFound(new NotFoundDTO("No settings defined. Please create settings to use the utility"));
                },
                (error) =>
                {
                    return InternalServerError(error.Exception);
                });
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Save Settings", Description = "Create or update configuration settings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveAsync(SettingsDTO dto, CancellationToken cancellationToken)
        {
            var settings = _mapper.Map<Settings>(dto);
            var saveSettingsRequest = new SaveSettingsRequest(settings);
            var saveSettingsResponse = await _mediator.Send(saveSettingsRequest, cancellationToken);

            return saveSettingsResponse
                .Match((setting) =>
                {
                    return Ok();
                },
                (validationFailed) =>
                {
                    return BadRequest(validationFailed.Errors);
                },
                (error) =>
                {
                    return InternalServerError(error.Exception);
                });
        }
    }
}
