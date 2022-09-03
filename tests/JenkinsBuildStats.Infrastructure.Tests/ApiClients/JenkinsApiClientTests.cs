using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Infrastructure.ApiClients;
using JenkinsBuildStats.Infrastructure.Exceptions;
using RichardSzalay.MockHttp;
using System.Text;

namespace JenkinsBuildStats.Infrastructure.Tests.ApiClients
{
    public class JenkinsApiClientTests
    {
        private readonly JenkinsClientConfig _jenkinsClientConfig = new JenkinsClientConfig
        {
            ApiToken = "Some Token",
            UserName = "Test username",
            BaseUrl = "https://faketestingjenkins.moq"
        };

        private const string _moqProjectName = nameof(_moqProjectName);

        [Fact]
        public async Task GetLastBuildLogsAsync_MockValidConsoleText_ProperlyParsedAndReturned()
        {
            var moqHttpHandler = new MockHttpMessageHandler();
            moqHttpHandler
                .When($"{_jenkinsClientConfig.BaseUrl}/job/{_moqProjectName}/lastSuccessfulBuild/timestamps/?time=HH:mm:ss&appendLog")
                .WithHeaders("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_jenkinsClientConfig.UserName}:{_jenkinsClientConfig.ApiToken}"))}")
                .Respond("text/plain", "05:57:11 test log line 1\r\n05:58:13 test log line 2\r\n05:59:01 test log line 3\r\n05:59:43 test log line 4");

            var client = new JenkinsApiClient(_jenkinsClientConfig, moqHttpHandler);
            var actual = await client.GetLastBuildLogsAsync(_moqProjectName, new CancellationToken());

            actual.Should().HaveCount(4);

            actual.ElementAt(0).TimeSpan.Should().Be(new TimeSpan(5, 57, 11));
            actual.ElementAt(0).LogText.Should().Be("05:57:11 test log line 1");

            actual.ElementAt(1).TimeSpan.Should().Be(new TimeSpan(5, 58, 13));
            actual.ElementAt(1).LogText.Should().Be("05:58:13 test log line 2");

            actual.ElementAt(2).TimeSpan.Should().Be(new TimeSpan(5, 59, 1));
            actual.ElementAt(2).LogText.Should().Be("05:59:01 test log line 3");

            actual.ElementAt(3).TimeSpan.Should().Be(new TimeSpan(5, 59, 43));
            actual.ElementAt(3).LogText.Should().Be("05:59:43 test log line 4");
        }

        [Fact]
        public async Task GetLastBuildLogsAsync_MockInvalidConsoleText_ThrowsException()
        {

            var moqHttpHandler = new MockHttpMessageHandler();
            moqHttpHandler
                .When($"{_jenkinsClientConfig.BaseUrl}/job/{_moqProjectName}/lastSuccessfulBuild/timestamps/?time=HH:mm:ss&appendLog")
                .WithHeaders("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_jenkinsClientConfig.UserName}:{_jenkinsClientConfig.ApiToken}"))}")
                .Respond("text/plain", "05:57:11 test log line 1\r\ninvalid log line without time\r\n05:59:01 test log line 3\r\n05:59:43 test log line 4");

            var client = new JenkinsApiClient(_jenkinsClientConfig, moqHttpHandler);
            Func<Task> act = async () =>
            {
                await client.GetLastBuildLogsAsync(_moqProjectName, new CancellationToken());
            };
            
            await act.Should().ThrowAsync<InvalidBuildConsoleOutputFormatException>().WithMessage("Invalid line 'invalid log line without time'. Console Output must have string formate - {time hh:mm:ss} {log text}");
        }
    }
}
