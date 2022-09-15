using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Processing
{
    public interface ILatestBuildStatsGenerator
    {
        Task<BuildStats> GenerateForProjectAsync(Project project,
            CancellationToken cancellationToken);
    }
}
