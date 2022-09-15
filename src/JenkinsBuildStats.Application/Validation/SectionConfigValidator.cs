using FluentValidation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Validation
{
    public sealed class SectionConfigValidator : AbstractValidator<SectionConfig>
    {
        public SectionConfigValidator()
        {
            RuleFor(sectionConfig => sectionConfig.Section)
                .NotNull()
                .WithMessage("Section is missing");
            RuleFor(sectionConfig => sectionConfig.Section)
                .SetValidator(new SectionValidator());

            RuleFor(sectionConfig => sectionConfig.StartsWith)
                .NotEmpty()
                .WithMessage("Section Starts With is missing");

            RuleFor(sectionConfig => sectionConfig.EndsWith)
                .NotEmpty()
                .WithMessage("Section Ends With is missing");
        }
    }
}
