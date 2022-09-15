using FluentValidation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Validation
{
    public sealed class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(section => section.Name)
                .NotEmpty()
                .WithMessage("Section Name is empty");
        }
    }
}
