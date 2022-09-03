using JenkinsBuildStats.Domain.Responses;
using MediatR;

namespace JenkinsBuildStats.Domain.Requests
{
    public class GetSettingsRequest : IRequest<GetSettingsResponse>
    {
    }
}
