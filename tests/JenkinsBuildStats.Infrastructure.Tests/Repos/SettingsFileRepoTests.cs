using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Infrastructure.DataStorage;
using JenkinsBuildStats.Infrastructure.Repos;

namespace JenkinsBuildStats.Infrastructure.Tests.Repos
{
    public class SettingsFileRepoTests
    {
        [Fact]
        public async Task GetAsync_MoqFileStorage_MethodCalledWithValidParams()
        {
            var expected = new Settings();
            var fileStorageMock = new Mock<IFileStorage>();

            fileStorageMock
                .Setup(x => x.GetAsync<Settings>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expected));

            var repo = new SettingsFileRepo(fileStorageMock.Object);

            var actual = await repo.GetAsync(new CancellationToken());

            actual.Should().BeSameAs(expected);

            fileStorageMock
                .Verify(x => x.GetAsync<Settings>(nameof(Settings), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task SaveAsync_MoqFileStorage_MethodCalledWithValidParams()
        {
            var moqObject = new Settings();
            var fileStorageMock = new Mock<IFileStorage>();


            var repo = new SettingsFileRepo(fileStorageMock.Object);

            await repo.SaveAsync(moqObject, new CancellationToken());

            fileStorageMock
                .Verify(x => x.SaveAsync(nameof(Settings), moqObject, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
