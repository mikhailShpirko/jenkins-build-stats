namespace JenkinsBuildStats.API.DTO
{
    public sealed class JenkinsClientConfigDTO
    {
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string ApiToken { get; set; }
    }
}
