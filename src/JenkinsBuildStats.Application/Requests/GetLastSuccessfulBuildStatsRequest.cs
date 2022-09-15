using JenkinsBuildStats.Application.Responses;
using MediatR;

namespace JenkinsBuildStats.Application.Requests
{
    public class GetLastSuccessfulBuildStatsRequest : IRequest<GetLastSuccessfulBuildStatsResponse>
    {
    }
}
