namespace JenkinsBuildStats.API.DTO
{
    public class SectionConfigDTO
    {
        public SectionDTO Section { get; set; }
        public string StartsWith { get; set; }
        public string EndsWith { get; set; }
    }
}
