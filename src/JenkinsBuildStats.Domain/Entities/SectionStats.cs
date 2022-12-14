namespace JenkinsBuildStats.Domain.Entities
{
    public sealed class SectionStats
    {
        public Section Section { get; init; }
        public TimeSpan StartedAt { get; init; }
        public TimeSpan EndedAt { get; init; }
        public TimeSpan Duration => EndedAt - StartedAt;
    }
}
