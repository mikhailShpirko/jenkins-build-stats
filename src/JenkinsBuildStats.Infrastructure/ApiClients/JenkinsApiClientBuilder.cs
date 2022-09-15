using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Infrastructure.ApiClients
{
    public sealed class JenkinsApiClientBuilder : IJenkinsApiClientBuilder
    {
        public IJenkinsApiClient Build(JenkinsClientConfig jenkinsClientConfig)
        {
            return new JenkinsApiClient(jenkinsClientConfig, new HttpClientHandler());
        }
    }
}
