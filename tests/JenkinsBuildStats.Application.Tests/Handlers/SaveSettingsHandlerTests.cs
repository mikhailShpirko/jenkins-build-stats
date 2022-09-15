using FluentValidation;
using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Handlers;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Application.Validation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Handlers
{
    public class SaveSettingsHandlerTests
    {
        private readonly IValidator<Settings> _validator = new SettingsValidator();

        [Fact]
        public async Task Handle_NullRequest_ArgumentNullException()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            var handler = new SaveSettingsHandler(repoMoq.Object, _validator);

            var response = await handler.Handle(null, new CancellationToken());

            response.IsT2.Should().Be(true);
            response.AsT2.Exception.Should().BeOfType<ArgumentNullException>();
            response.AsT2.Exception.As<ArgumentNullException>().ParamName.Should().Be("request");
        }

        [Fact]
        public async Task Handle_NullSettings_ArgumentNullException()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            var handler = new SaveSettingsHandler(repoMoq.Object, _validator);
            var request = new SaveSettingsRequest(null);

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT2.Should().Be(true);
            response.AsT2.Exception.Should().BeOfType<ArgumentNullException>();
            response.AsT2.Exception.As<ArgumentNullException>().ParamName.Should().Be("Settings");
        }

        [Fact]
        public async Task Handle_InvalidSettings_ValidationFailed()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            var handler = new SaveSettingsHandler(repoMoq.Object, _validator);
            var request = new SaveSettingsRequest(new Settings());

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT1.Should().Be(true);
            response.AsT1.Errors.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public async Task Handle_ValidSettings_SuccessfullySaved()
        {
            var repoMoq = new Mock<ISettingsRepo>();

            var handler = new SaveSettingsHandler(repoMoq.Object, _validator);

            var settings = new Settings
            {
                JenkinsClientConfig = new JenkinsClientConfig
                {
                    BaseUrl = "https://jenkins.org",
                    UserName = "UserName",
                    ApiToken = "ApiToken"
                },
                SectionConfigs = new List<SectionConfig> 
                { 
                    new SectionConfig
                    {
                        Section = new Section
                        {
                            Name = "Section"
                        },
                        StartsWith = "StartsWith",
                        EndsWith = "EndsWith"
                    } 
                },
                Projects = new List<Project>
                {
                    new Project
                    {
                        Name = "Project"
                    }
                }
            };
            var request = new SaveSettingsRequest(settings);

            var response = await handler.Handle(request, new CancellationToken());

            response.IsT0.Should().Be(true);
            response.AsT0.Should().BeOfType<SuccessfullySaved<Settings>>(); 
        }
    }
}
