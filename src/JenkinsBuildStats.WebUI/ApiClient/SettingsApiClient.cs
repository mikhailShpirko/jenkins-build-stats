using JenkinsBuildStats.API.DTO;
using OneOf;

namespace JenkinsBuildStats.WebUI.ApiClient
{
    public class SettingsApiClient : BaseApiClient
    {
        private const string _baseUri = "Settings";
        public SettingsApiClient(HttpClient client) 
            : base(client)
        {
        }

        public async Task<OneOf<SettingsDTO, NotFoundDTO, InternalServerErrorDTO, UnexpectedResponse>> GetAsync()
        {
            return await GetAsync<SettingsDTO>(_baseUri);
        }

        public async Task<OneOf<OkResponse, NotFoundDTO, BadRequestDTO, InternalServerErrorDTO, UnexpectedResponse>> SaveAsync(SettingsDTO settings)
        {
            return await PutAsync(_baseUri, settings);
        }
    }
}
