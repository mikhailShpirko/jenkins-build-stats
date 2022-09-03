namespace JenkinsBuildStats.API.DTO
{
    public class BuildStatsDTO
    {
        public ProjectDTO Project { get; set; }
        public IReadOnlyCollection<SectionStatsDTO> SectionsStats { get; set; }
        public TimeSpan StartedAt { get; set; }
        public TimeSpan EndedAt { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
