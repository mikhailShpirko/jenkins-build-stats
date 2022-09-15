using FluentValidation.TestHelper;
using JenkinsBuildStats.Application.Validation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Validation
{
    public class SettingsValidatorTests
    {
        private readonly SettingsValidator _validator = new SettingsValidator();

        [Fact]
        public async Task NoJenkinsClientConfig_ShouldHaveValidationErrorForJenkinsClientConfig()
        {
            var model = new Settings();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.JenkinsClientConfig);
        }

        [Fact]
        public async Task JenkinsClientConfigDefined_ShouldNotHaveValidationErrorForJenkinsClientConfig()
        {
            var model = new Settings
            {
                JenkinsClientConfig = new JenkinsClientConfig()
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.JenkinsClientConfig);
        }

        [Fact]
        public async Task NoSectionConfigs_ShouldHaveValidationErrorForSectionConfigs()
        {
            var model = new Settings();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.SectionConfigs);
        }

        [Fact]
        public async Task EmptySectionConfigs_ShouldHaveValidationErrorForSectionConfigs()
        {
            var model = new Settings
            {
                SectionConfigs = new List<SectionConfig> { }
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.SectionConfigs);
        }

        [Fact]
        public async Task SectionConfigsDefined_ShouldNotHaveValidationErrorForSectionConfigs()
        {
            var model = new Settings
            {
                SectionConfigs = new List<SectionConfig> { new SectionConfig() }
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.SectionConfigs);
        }

        [Fact]
        public async Task NoProjects_ShouldHaveValidationErrorForProjects()
        {
            var model = new Settings();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Projects);
        }

        [Fact]
        public async Task EmptyProjects_ShouldHaveValidationErrorForProjects()
        {
            var model = new Settings
            {
                Projects = new List<Project> { }
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Projects);
        }

        [Fact]
        public async Task ProjectsDefined_ShouldNotHaveValidationErrorForProjects()
        {
            var model = new Settings
            {
                Projects = new List<Project> { new Project() }
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Projects);
        }
    }
}
