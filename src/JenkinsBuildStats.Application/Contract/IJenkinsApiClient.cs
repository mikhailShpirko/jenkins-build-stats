using JenkinsBuildStats.Application.Processing;

namespace JenkinsBuildStats.Application.Contract
{
    public interface IJenkinsApiClient
    {
        Task<IReadOnlyCollection<BuildOutputLog>> GetLastBuildLogsAsync(string projectName,
            CancellationToken cancellationToken);
    }
}
