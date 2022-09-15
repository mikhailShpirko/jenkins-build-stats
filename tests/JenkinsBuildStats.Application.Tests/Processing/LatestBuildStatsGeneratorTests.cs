using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Processing;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Processing
{
    public class LatestBuildStatsGeneratorTests
    {
        [Fact]
        public async Task GenerateForProjectAsync_MockBuildLogs_ProperlyProcessed()
        {
            var project = new Project
            {
                Name = "Test Project"
            };

            var sectionsConfig = new List<SectionConfig>
            {
                new SectionConfig
                {
                    Section = new Section
                    {
                        Name = "section 1"
                    },
                    StartsWith = "section 1 started",
                    EndsWith = "section 1 finished"
                },
                new SectionConfig
                {
                    Section = new Section
                    {
                        Name = "section 2"
                    },
                    StartsWith = "section 2 started",
                    EndsWith = "section 2 finished"
                }
            };

            var logs = new List<BuildOutputLog>
            {
                new BuildOutputLog(new TimeSpan(5,30,1), "build started"),
                new BuildOutputLog(new TimeSpan(5,32,5), "section 1 started"),
                new BuildOutputLog(new TimeSpan(5,35,13), "something is done"),
                new BuildOutputLog(new TimeSpan(5,37,17), "something is done"),
                new BuildOutputLog(new TimeSpan(5,40,26), "section 1 finished"),
                new BuildOutputLog(new TimeSpan(5,50,31), "something is done"),
                new BuildOutputLog(new TimeSpan(6,20,48), "section 2 started"),
                new BuildOutputLog(new TimeSpan(6,30,55), "something is done"),
                new BuildOutputLog(new TimeSpan(7,15,3), "section 2 finished"),
                new BuildOutputLog(new TimeSpan(7,30,45), "something is done"),
                new BuildOutputLog(new TimeSpan(8,00,1), "build finished"),
            };

            var apiClientMock = new Mock<IJenkinsApiClient>();
            apiClientMock
                .Setup(x => x.GetLastBuildLogsAsync(project.Name, new CancellationToken()))
                .Returns(Task.FromResult((IReadOnlyCollection<BuildOutputLog>)logs));

            var generator = new LatestBuildStatsGenerator(apiClientMock.Object, sectionsConfig);

            var actual = await generator.GenerateForProjectAsync(project, new CancellationToken());

            actual.Project.Should().BeSameAs(project);

            actual.StartedAt.Should().Be(new TimeSpan(5, 30, 1));
            actual.EndedAt.Should().Be(new TimeSpan(8, 00, 1));
            actual.Duration.Should().Be(new TimeSpan(2, 30, 0));

            actual.SectionsStats.Should().HaveCount(2);

            actual.SectionsStats.ElementAt(0).Section.Should().BeSameAs(sectionsConfig.ElementAt(0).Section);
            actual.SectionsStats.ElementAt(0).StartedAt.Should().Be(new TimeSpan(5, 32, 5));
            actual.SectionsStats.ElementAt(0).EndedAt.Should().Be(new TimeSpan(5, 40, 26));
            actual.SectionsStats.ElementAt(0).Duration.Should().Be(new TimeSpan(0, 8, 21));

            actual.SectionsStats.ElementAt(1).Section.Should().BeSameAs(sectionsConfig.ElementAt(1).Section);
            actual.SectionsStats.ElementAt(1).StartedAt.Should().Be(new TimeSpan(6, 20, 48));
            actual.SectionsStats.ElementAt(1).EndedAt.Should().Be(new TimeSpan(7, 15, 3));
            actual.SectionsStats.ElementAt(1).Duration.Should().Be(new TimeSpan(0, 54, 15));
        }
    }
}
