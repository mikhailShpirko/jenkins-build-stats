namespace JenkinsBuildStats.Domain.Entities
{
    public sealed class Settings
    {     
        public JenkinsClientConfig JenkinsClientConfig { get; init; }

        public IReadOnlyCollection<SectionConfig> SectionConfigs { get; init; }
        public IReadOnlyCollection<Project> Projects { get; init; }
    }
}
