using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Infrastructure.ApiClients
{
    public class JenkinsApiClientBuilder : IJenkinsApiClientBuilder
    {
        public IJenkinsApiClient Build(JenkinsClientConfig jenkinsClientConfig)
        {
            return new JenkinsApiClient(jenkinsClientConfig, new HttpClientHandler());
        }
    }
}
