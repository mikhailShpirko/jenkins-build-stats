using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Domain.Processing
{
    public interface ILatestBuildStatsGeneratorBuilder
    {
        ILatestBuildStatsGenerator Build(JenkinsClientConfig jenkinsClientConfig,
            IReadOnlyCollection<SectionConfig> sectionConfigs);
    }
}
