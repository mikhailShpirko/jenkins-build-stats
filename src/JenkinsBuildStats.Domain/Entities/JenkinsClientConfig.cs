namespace JenkinsBuildStats.Domain.Entities
{
    public sealed class JenkinsClientConfig
    {
        public string BaseUrl { get; init; }
        public string UserName { get; init; }
        public string ApiToken { get; init; }
    }
}
