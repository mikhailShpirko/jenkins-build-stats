using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JenkinsBuildStats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildStatsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public BuildStatsController(IMapper mapper,
            IMediator mediator, 
            ILogger<BuildStatsController> logger) : base(logger)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Build Stats", Description = "Get stats of latest build for all projects")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LastSuccessfulBuildStatsDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        public async Task<IActionResult> GetLatestBuildStatsAsync(CancellationToken cancellationToken)
        {
            var getBuildStatsRequest = new GetLastSuccessfulBuildStatsRequest();
            var getBuildStatsResponse = await _mediator.Send(getBuildStatsRequest, cancellationToken);

            return getBuildStatsResponse
                .Match((buildStats) =>
                {
                    var dto = _mapper.Map<LastSuccessfulBuildStatsDTO>(buildStats);
                    return Ok(dto);
                },
                (noBuildStats) =>
                {
                    return NotFound(new NotFoundDTO("No last successfult build stats available. Call the relevant API endpoint to generate ones"));
                },
                (error) =>
                {
                    return InternalServerError(error.Exception);
                });
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Generate Build Stats", Description = "Generate stats of latest build for all projects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        public async Task<IActionResult> GenerateLatestBuildStatsAsync(CancellationToken cancellationToken)
        {
            var generateBuildStatsRequest = new GenerateLastSuccessfulBuildStatsRequest();
            var generateBuildStatsResponse = await _mediator.Send(generateBuildStatsRequest, cancellationToken);

            return generateBuildStatsResponse
                .Match((success) =>
                {
                    return Ok();
                },
                (noSettings) =>
                {
                    return NotFound(new NotFoundDTO("No settings defined. Call relevant API endpoint first to save settings"));
                },
                (error) =>
                {
                    return InternalServerError(error.Exception);
                });
        }
    }
}
