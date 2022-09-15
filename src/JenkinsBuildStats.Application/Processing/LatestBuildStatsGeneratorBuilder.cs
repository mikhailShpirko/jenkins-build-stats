using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Processing
{
    public sealed class LatestBuildStatsGeneratorBuilder : ILatestBuildStatsGeneratorBuilder
    {
        private readonly IJenkinsApiClientBuilder _jenkinsApiClientBuilder;

        public LatestBuildStatsGeneratorBuilder(IJenkinsApiClientBuilder jenkinsApiClientBuilder)
        {
            _jenkinsApiClientBuilder = jenkinsApiClientBuilder;
        }

        public ILatestBuildStatsGenerator Build(JenkinsClientConfig jenkinsClientConfig, 
            IReadOnlyCollection<SectionConfig> sectionConfigs)
        {
            return new LatestBuildStatsGenerator(_jenkinsApiClientBuilder.Build(jenkinsClientConfig),
                sectionConfigs);
        }
    }
}
