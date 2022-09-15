namespace JenkinsBuildStats.API.DTO
{
    public sealed class LastSuccessfulBuildStatsDTO
    {
        public IReadOnlyCollection<BuildStatsDTO> BuildStats { get; set; }
    }
}
