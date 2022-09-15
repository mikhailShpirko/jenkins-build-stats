using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Handlers;
using JenkinsBuildStats.Application.Processing;
using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Handlers
{
    public class GenerateLastSuccessfulBuildStatsHandlerTests
    {
        private readonly Settings _mockSettings = new Settings
        {
            JenkinsClientConfig = new JenkinsClientConfig
            {
                ApiToken = "Some Token",
                UserName = "Test username",
                BaseUrl = "https://faketestingjenkins.moq"
            },
            Projects = new List<Project>
            {
                new Project
                {
                    Name = "Test Project 1"
                },
                new Project
                {
                    Name = "Test Project 2"
                }
            },
            SectionConfigs = new List<SectionConfig>
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
            }
        };

        [Fact]
        public async Task Handle_SettingsRepoThrowsException_ErrorDuringProcessing()
        {
            var exceptionThrown = new ArithmeticException();

            var settingsRepoMock = new Mock<ISettingsRepo>();
            settingsRepoMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Throws(exceptionThrown);

            var generatorBuilderMock = new Mock<ILatestBuildStatsGeneratorBuilder>();
            var generatorMock = new Mock<ILatestBuildStatsGenerator>();
            generatorBuilderMock
                .Setup(x => x.Build(It.IsAny<JenkinsClientConfig>(), It.IsAny<IReadOnlyCollection<SectionConfig>>()))
                .Returns(generatorMock.Object);
            var repoMock = new Mock<ILastSuccessfulBuildStatsRepo>();

            var handler = new GenerateLastSuccessfulBuildStatsHandler(settingsRepoMock.Object,
                generatorBuilderMock.Object,
                repoMock.Object);

            var actual = await handler.Handle(null, new CancellationToken());

            actual.IsT2.Should().BeTrue();
            actual.AsT2.Exception.Should().BeSameAs(exceptionThrown);
        }

        [Fact]
        public async Task Handle_SettingsRepoReturnsNull_EntityDoesNotExist()
        {
            var settingsRepoMock = new Mock<ISettingsRepo>();
            settingsRepoMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((Settings)null));

            var generatorBuilderMock = new Mock<ILatestBuildStatsGeneratorBuilder>();
            var generatorMock = new Mock<ILatestBuildStatsGenerator>();
            generatorBuilderMock
                .Setup(x => x.Build(It.IsAny<JenkinsClientConfig>(), It.IsAny<IReadOnlyCollection<SectionConfig>>()))
                .Returns(generatorMock.Object);
            var repoMock = new Mock<ILastSuccessfulBuildStatsRepo>();

            var handler = new GenerateLastSuccessfulBuildStatsHandler(settingsRepoMock.Object,
                generatorBuilderMock.Object,
                repoMock.Object);

            var actual = await handler.Handle(null, new CancellationToken());

            actual.IsT1.Should().BeTrue();
            actual.AsT1.Should().BeOfType<EntityDoesNotExist<Settings>>();
        }

        [Fact]
        public async Task Handle_GeneratorBuilderThrowsException_ErrorDuringProcessing()
        {
            var exceptionThrown = new ArithmeticException();

            var settingsRepoMock = new Mock<ISettingsRepo>();
            settingsRepoMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_mockSettings));

            var generatorBuilderMock = new Mock<ILatestBuildStatsGeneratorBuilder>();
            var generatorMock = new Mock<ILatestBuildStatsGenerator>();
            generatorBuilderMock
                .Setup(x => x.Build(It.IsAny<JenkinsClientConfig>(), It.IsAny<IReadOnlyCollection<SectionConfig>>()))
                .Throws(exceptionThrown);
            var repoMock = new Mock<ILastSuccessfulBuildStatsRepo>();

            var handler = new GenerateLastSuccessfulBuildStatsHandler(settingsRepoMock.Object,
                generatorBuilderMock.Object,
                repoMock.Object);

            var actual = await handler.Handle(null, new CancellationToken());

            actual.IsT2.Should().BeTrue();
            actual.AsT2.Exception.Should().BeSameAs(exceptionThrown);
        }

        [Fact]
        public async Task Handle_GeneratorThrowsException_ErrorDuringProcessing()
        {
            var exceptionThrown = new ArithmeticException();

            var settingsRepoMock = new Mock<ISettingsRepo>();
            settingsRepoMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_mockSettings));

            var generatorBuilderMock = new Mock<ILatestBuildStatsGeneratorBuilder>();
            var generatorMock = new Mock<ILatestBuildStatsGenerator>();
            generatorMock
               .Setup(x => x.GenerateForProjectAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
               .Throws(exceptionThrown);

            generatorBuilderMock
                .Setup(x => x.Build(It.IsAny<JenkinsClientConfig>(), It.IsAny<IReadOnlyCollection<SectionConfig>>()))
                .Returns(generatorMock.Object);
            var repoMock = new Mock<ILastSuccessfulBuildStatsRepo>();

            var handler = new GenerateLastSuccessfulBuildStatsHandler(settingsRepoMock.Object,
                generatorBuilderMock.Object,
                repoMock.Object);

            var actual = await handler.Handle(null, new CancellationToken());

            actual.IsT2.Should().BeTrue();
            actual.AsT2.Exception.Should().BeSameAs(exceptionThrown);
        }

        [Fact]
        public async Task Handle_MockDependencies_ProperExecutionFlow()
        {
            var settingsRepoMock = new Mock<ISettingsRepo>();
            settingsRepoMock.Setup(x => x.GetAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(_mockSettings));

            var generatorBuilderMock = new Mock<ILatestBuildStatsGeneratorBuilder>();
            var generatorMock = new Mock<ILatestBuildStatsGenerator>();
            generatorMock
               .Setup(x => x.GenerateForProjectAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
               .Returns((Project project, CancellationToken token) => Task.FromResult(new BuildStats
               {
                   Project = project
               }));

            generatorBuilderMock
                .Setup(x => x.Build(It.IsAny<JenkinsClientConfig>(), It.IsAny<IReadOnlyCollection<SectionConfig>>()))
                .Returns(generatorMock.Object);
            var repoMock = new Mock<ILastSuccessfulBuildStatsRepo>();

            var handler = new GenerateLastSuccessfulBuildStatsHandler(settingsRepoMock.Object,
                generatorBuilderMock.Object,
                repoMock.Object);

            var actual = await handler.Handle(null, new CancellationToken());


            generatorBuilderMock.Verify(x => x.Build(_mockSettings.JenkinsClientConfig, _mockSettings.SectionConfigs), Times.Once);
            settingsRepoMock.Verify(x => x.GetAsync(It.IsAny<CancellationToken>()), Times.Once);
            repoMock.Verify(x => x.SaveAsync(It.IsAny<LastSuccessfulBuildStats>(), It.IsAny<CancellationToken>()), Times.Once);
            generatorMock.Verify(x => x.GenerateForProjectAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            actual.IsT0.Should().BeTrue();
            actual.AsT0.Should().BeOfType<SuccessfullySaved<LastSuccessfulBuildStats>>();

        }
    }
}
