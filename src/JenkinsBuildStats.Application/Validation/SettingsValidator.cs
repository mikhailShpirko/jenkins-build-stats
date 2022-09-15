using FluentValidation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Validation
{
    public sealed class SettingsValidator : AbstractValidator<Settings>
    {
        public SettingsValidator()
        {
            RuleFor(setting => setting.JenkinsClientConfig)
                .NotNull()
                .WithMessage("Jenkins Config is missing");
            RuleFor(setting => setting.JenkinsClientConfig)
                .SetValidator(new JenkinsClientConfigValidator());

            RuleFor(setting => setting.SectionConfigs)
                .NotEmpty()
                .WithMessage("Sections not defined");
            RuleForEach(setting => setting.SectionConfigs)
                .SetValidator(new SectionConfigValidator());

            RuleFor(setting => setting.Projects)
                .NotEmpty()
                .WithMessage("Projects not defined");
            RuleForEach(setting => setting.Projects)
                .SetValidator(new ProjectValidator());
        }
    }
}
