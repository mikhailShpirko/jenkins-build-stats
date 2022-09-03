using JenkinsBuildStats.API.DTO;
using OneOf;

namespace JenkinsBuildStats.WebUI.ApiClient
{
    public class BuildStatsApiClient : BaseApiClient
    {
        private const string _baseUri = "BuildStats";
        public BuildStatsApiClient(HttpClient client) 
            : base(client)
        {
        }

        public async Task<OneOf<LastSuccessfulBuildStatsDTO, NotFoundDTO, InternalServerErrorDTO, UnexpectedResponse>> GetAsync()
        {
            return await GetAsync<LastSuccessfulBuildStatsDTO>(_baseUri);
        }

        public async Task<OneOf<OkResponse, NotFoundDTO, BadRequestDTO, InternalServerErrorDTO, UnexpectedResponse>> GenerateAsync()
        {
            return await PutAsync(_baseUri, new { });
        }
    }
}
