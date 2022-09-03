using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Domain.Contract
{
    public interface IJenkinsApiClientBuilder
    {
        IJenkinsApiClient Build(JenkinsClientConfig jenkinsClientConfig);
    }
}
