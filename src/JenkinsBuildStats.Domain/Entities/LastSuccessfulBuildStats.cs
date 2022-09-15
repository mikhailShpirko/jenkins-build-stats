namespace JenkinsBuildStats.Domain.Entities
{
    public sealed class LastSuccessfulBuildStats
    {
        public IReadOnlyCollection<BuildStats> BuildStats { get; init; }
    }
}
