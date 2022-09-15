using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Contract
{
    public interface IJenkinsApiClient
    {
        Task<IReadOnlyCollection<BuildOutputLog>> GetLastBuildLogsAsync(string projectName,
            CancellationToken cancellationToken);
    }
}
