using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Domain.Processing
{
    public interface ILatestBuildStatsGenerator
    {
        Task<BuildStats> GenerateForProjectAsync(Project project,
            CancellationToken cancellationToken);
    }
}
