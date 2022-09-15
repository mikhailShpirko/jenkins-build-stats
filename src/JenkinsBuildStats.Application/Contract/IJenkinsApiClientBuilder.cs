using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Contract
{
    public interface IJenkinsApiClientBuilder
    {
        IJenkinsApiClient Build(JenkinsClientConfig jenkinsClientConfig);
    }
}
