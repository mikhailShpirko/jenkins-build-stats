using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Handlers;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Handlers
{
    public class GetLastSuccessfulBuildStatsHandlerTests
    {
        [Fact]
        public async Task Handle_RepoThrowsException_ErrorDuringProcessing()
        {
            var repoMoq = new Mock<ILastSuccessfulBuildStatsRepo>();

            var exceptionThrown = new ArithmeticException();

            repoMoq
                .Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Throws(exceptionThrown);

            var handler = new GetLastSuccessfulBuildStatsHandler(repoMoq.Object);

            var request = new GetLastSuccessfulBuildStatsRequest();

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT2.Should().Be(true);
            response.AsT2.Exception.Should().BeSameAs(exceptionThrown);
        }

        [Fact]
        public async Task Handle_RepoReturnsNull_EntityDoesNotExist()
        {
            var repoMoq = new Mock<ILastSuccessfulBuildStatsRepo>();

            repoMoq
                .Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((LastSuccessfulBuildStats)null));

            var handler = new GetLastSuccessfulBuildStatsHandler(repoMoq.Object);

            var request = new GetLastSuccessfulBuildStatsRequest();

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT1.Should().Be(true);
            response.AsT1.Should().NotBeNull();
        }

        [Fact]
        public async Task Handle_RepoReturnsSettings_SettingMapped()
        {
            var repoMoq = new Mock<ILastSuccessfulBuildStatsRepo>();

            var settings = new LastSuccessfulBuildStats();

            repoMoq
                .Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(settings));

            var handler = new GetLastSuccessfulBuildStatsHandler(repoMoq.Object);

            var request = new GetLastSuccessfulBuildStatsRequest();

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT0.Should().Be(true);
            response.AsT0.Should().BeSameAs(settings);
        }
    }
}
