namespace JenkinsBuildStats.Domain.Entities
{
    public class BuildStats
    {
        public Project Project { get; init; }
        public IReadOnlyCollection<SectionStats> SectionsStats { get; init; }
        public TimeSpan StartedAt { get; init; }
        public TimeSpan EndedAt { get; init; }
        public TimeSpan Duration => EndedAt - StartedAt;
    }
}
