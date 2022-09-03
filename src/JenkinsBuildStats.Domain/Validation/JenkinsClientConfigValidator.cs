using FluentValidation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Domain.Validation
{
    public class JenkinsClientConfigValidator : AbstractValidator<JenkinsClientConfig>
    {
        public JenkinsClientConfigValidator()
        {
            RuleFor(jenkinsClientConfig => jenkinsClientConfig.BaseUrl)
               .NotEmpty()
               .WithMessage("Jenkins Base Url is missing")
               .Must(IsUrl)
               .WithMessage("Jenkins Base Url '{PropertyValue}' is not a valid URL");

            RuleFor(jenkinsClientConfig => jenkinsClientConfig.UserName)
                .NotEmpty()
                .WithMessage("Jenkins UserName is missing");

            RuleFor(jenkinsClientConfig => jenkinsClientConfig.ApiToken)
                .NotEmpty()
                .WithMessage("Jenkins API Token is missing");
        }
        private static bool IsUrl(string baseUrl)
        {
            return Uri.TryCreate(baseUrl, UriKind.Absolute, out _);
        }
    }
}
