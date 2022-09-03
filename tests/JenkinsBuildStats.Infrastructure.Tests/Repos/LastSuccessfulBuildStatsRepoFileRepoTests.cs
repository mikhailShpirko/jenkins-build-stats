using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Infrastructure.DataStorage;
using JenkinsBuildStats.Infrastructure.Repos;

namespace JenkinsBuildStats.Infrastructure.Tests.Repos
{
    public class LastSuccessfulBuildStatsRepoFileRepoTests
    {
        [Fact]
        public async Task GetAsync_MoqFileStorage_MethodCalledWithValidParams()
        {
            var expected = new LastSuccessfulBuildStats();
            var fileStorageMock = new Mock<IFileStorage>();

            fileStorageMock
                .Setup(x => x.GetAsync<LastSuccessfulBuildStats>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expected));

            var repo = new LastSuccessfulBuildStatsRepoFileRepo(fileStorageMock.Object);

            var actual = await repo.GetAsync(new CancellationToken());

            actual.Should().BeSameAs(expected);

            fileStorageMock
                .Verify(x => x.GetAsync<LastSuccessfulBuildStats>(nameof(LastSuccessfulBuildStats), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task SaveAsync_MoqFileStorage_MethodCalledWithValidParams()
        {
            var moqObject = new LastSuccessfulBuildStats();
            var fileStorageMock = new Mock<IFileStorage>();


            var repo = new LastSuccessfulBuildStatsRepoFileRepo(fileStorageMock.Object);

            await repo.SaveAsync(moqObject, new CancellationToken());

            fileStorageMock
                .Verify(x => x.SaveAsync(nameof(LastSuccessfulBuildStats), moqObject, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
