using FluentValidation.TestHelper;
using JenkinsBuildStats.Application.Validation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Validation
{
    public class JenkinsClientConfigValidatorTests
    {
        private readonly JenkinsClientConfigValidator _validator = new JenkinsClientConfigValidator();

        [Fact]
        public async Task NoBaseUrl_ShouldHaveValidationErrorForBaseUrl()
        {
            var model = new JenkinsClientConfig();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.BaseUrl);
        }

        [Fact]
        public async Task EmptyBaseUrl_ShouldHaveValidationErrorForBaseUrl()
        {
            var model = new JenkinsClientConfig
            {
                BaseUrl = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.BaseUrl);
        }

        [Fact]
        public async Task NotUrlBaseUrl_ShouldHaveValidationErrorForBaseUrl()
        {
            var model = new JenkinsClientConfig
            {
                BaseUrl = "not a url"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.BaseUrl);
        }

        [Fact]
        public async Task ValidBaseUrl_ShouldNotHaveValidationErrorForBaseUrl()
        {
            var model = new JenkinsClientConfig
            {
                BaseUrl = "https://jenkins.org"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.BaseUrl);
        }

        [Fact]
        public async Task NoUserName_ShouldHaveValidationErrorForUserName()
        {
            var model = new JenkinsClientConfig();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public async Task EmptyUserName_ShouldHaveValidationErrorForUserName()
        {
            var model = new JenkinsClientConfig
            {
                UserName = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public async Task UserNameDefined_ShouldNotHaveValidationErrorForUserName()
        {
            var model = new JenkinsClientConfig
            {
                UserName = "UserName"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public async Task NoApiToken_ShouldHaveValidationErrorForUserApiToken()
        {
            var model = new JenkinsClientConfig();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.ApiToken);
        }

        [Fact]
        public async Task EmptyApiToken_ShouldHaveValidationErrorForApiTokene()
        {
            var model = new JenkinsClientConfig
            {
                ApiToken = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.ApiToken);
        }

        [Fact]
        public async Task ApiTokenDefined_ShouldNotHaveValidationErrorForApiToken()
        {
            var model = new JenkinsClientConfig
            {
                ApiToken = "ApiToken"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.ApiToken);
        }
    }
}
