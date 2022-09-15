using JenkinsBuildStats.Application.Responses;
using MediatR;

namespace JenkinsBuildStats.Application.Requests
{
    public sealed class GetLastSuccessfulBuildStatsRequest : IRequest<GetLastSuccessfulBuildStatsResponse>
    {
    }
}
