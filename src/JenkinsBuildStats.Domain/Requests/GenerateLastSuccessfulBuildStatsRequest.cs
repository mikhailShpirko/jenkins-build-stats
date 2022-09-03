using JenkinsBuildStats.Domain.Responses;
using MediatR;

namespace JenkinsBuildStats.Domain.Requests
{
    public class GenerateLastSuccessfulBuildStatsRequest : IRequest<GenerateLastSuccessfulBuildStatsResponse>
    {
    }
}
