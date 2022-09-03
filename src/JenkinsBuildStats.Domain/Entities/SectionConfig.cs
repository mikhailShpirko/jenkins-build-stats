namespace JenkinsBuildStats.Domain.Entities
{
    public class SectionConfig
    {
        public Section Section { get; init; }
        public string StartsWith { get; init; }
        public string EndsWith { get; init; }
    }
}
