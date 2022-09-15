using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Processing
{
    public interface ILatestBuildStatsGeneratorBuilder
    {
        ILatestBuildStatsGenerator Build(JenkinsClientConfig jenkinsClientConfig,
            IReadOnlyCollection<SectionConfig> sectionConfigs);
    }
}
