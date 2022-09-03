using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Infrastructure.Exceptions;
using System.Text;

namespace JenkinsBuildStats.Infrastructure.ApiClients
{
    public class JenkinsApiClient : IJenkinsApiClient
    {
        private readonly JenkinsClientConfig _jenkinsClientConfig;
        private readonly HttpMessageHandler _httpMessageHandler;

        public JenkinsApiClient(JenkinsClientConfig jenkinsClientConfig,
            HttpMessageHandler httpMessageHandler)
        {
            _jenkinsClientConfig = jenkinsClientConfig;
            _httpMessageHandler = httpMessageHandler;
        }

        public async Task<IReadOnlyCollection<BuildOutputLog>> GetLastBuildLogsAsync(string projectName, 
            CancellationToken cancellationToken)
        {
            using var client = new HttpClient(_httpMessageHandler)
            {
                BaseAddress = new Uri(_jenkinsClientConfig.BaseUrl),
            };

            client
                .DefaultRequestHeaders
                .Add("Authorization", 
                    $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_jenkinsClientConfig.UserName}:{_jenkinsClientConfig.ApiToken}"))}");

            var latestBuildConsoleText = await client
                .GetStringAsync($"/job/{projectName}/lastSuccessfulBuild/timestamps/?time=HH:mm:ss&appendLog", 
                    cancellationToken);


            return latestBuildConsoleText
                .Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.RemoveEmptyEntries
                )
                .Select(l => new BuildOutputLog(GetTimespanFromLogLine(l), 
                    l))
                .ToList();
        }

        private TimeSpan GetTimespanFromLogLine(ReadOnlySpan<char> line)
        {
            if (!TimeSpan.TryParse(line.Slice(0, 8), out var timespan))
            {
                throw new InvalidBuildConsoleOutputFormatException(line.ToString());
            }
            return timespan;
        }
    }
}
