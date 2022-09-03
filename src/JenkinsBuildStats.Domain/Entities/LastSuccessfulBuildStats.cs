namespace JenkinsBuildStats.Domain.Entities
{
    public class LastSuccessfulBuildStats
    {
        public IReadOnlyCollection<BuildStats> BuildStats { get; init; }
    }
}
