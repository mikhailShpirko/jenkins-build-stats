using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Domain.Handlers;
using JenkinsBuildStats.Domain.Requests;

namespace JenkinsBuildStats.Domain.Tests.Handlers
{
    public class GetSettingsHandlerTests
    {
        [Fact]
        public async Task Handle_RepoThrowsException_ErrorDuringProcessing()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            var exceptionThrown = new ArithmeticException();

            repoMoq
                .Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Throws(exceptionThrown);

            var handler = new GetSettingsHandler(repoMoq.Object);

            var request = new GetSettingsRequest();

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT2.Should().Be(true);
            response.AsT2.Exception.Should().BeSameAs(exceptionThrown);
        }

        [Fact]
        public async Task Handle_RepoReturnsNull_EntityDoesNotExist()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            repoMoq
                .Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((Settings)null));

            var handler = new GetSettingsHandler(repoMoq.Object);

            var request = new GetSettingsRequest();

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT1.Should().Be(true);
            response.AsT1.Should().NotBeNull();
        }

        [Fact]
        public async Task Handle_RepoReturnsSettings_SettingMapped()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            var settings = new Settings();

            repoMoq
                .Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(settings));

            var handler = new GetSettingsHandler(repoMoq.Object);

            var request = new GetSettingsRequest();

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT0.Should().Be(true);
            response.AsT0.Should().BeSameAs(settings);
        }
    }
}
