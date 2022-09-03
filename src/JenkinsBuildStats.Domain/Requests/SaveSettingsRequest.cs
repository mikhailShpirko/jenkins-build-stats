using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Domain.Responses;
using MediatR;

namespace JenkinsBuildStats.Domain.Requests
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
