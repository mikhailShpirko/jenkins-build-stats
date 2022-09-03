using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Domain.Contract
{
    public interface IJenkinsApiClient
    {
        Task<IReadOnlyCollection<BuildOutputLog>> GetLastBuildLogsAsync(string projectName,
            CancellationToken cancellationToken);
    }
}
