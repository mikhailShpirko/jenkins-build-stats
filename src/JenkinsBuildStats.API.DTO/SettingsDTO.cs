namespace JenkinsBuildStats.API.DTO
{
    public sealed class SettingsDTO
    {
        public JenkinsClientConfigDTO JenkinsClientConfig { get; set; }

        public List<SectionConfigDTO> SectionConfigs { get; set; }
        public List<ProjectDTO> Projects { get; set; }
    }
}
