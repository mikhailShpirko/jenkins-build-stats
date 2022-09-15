using JenkinsBuildStats.Application.Responses;
using MediatR;

namespace JenkinsBuildStats.Application.Requests
{
    public class GetSettingsRequest : IRequest<GetSettingsResponse>
    {
    }
}
