namespace JenkinsBuildStats.API.DTO
{
    public class LastSuccessfulBuildStatsDTO
    {
        public IReadOnlyCollection<BuildStatsDTO> BuildStats { get; set; }
    }
}
