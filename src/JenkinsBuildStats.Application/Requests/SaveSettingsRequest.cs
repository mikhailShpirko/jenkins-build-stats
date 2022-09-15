using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Domain.Entities;
using MediatR;

namespace JenkinsBuildStats.Application.Requests
{
    public class SaveSettingsRequest : IRequest<SaveSettingsResponse>
    {
        public readonly Settings Settings;

        public SaveSettingsRequest(Settings settings)
        {
            Settings = settings;
        }
    }
}
