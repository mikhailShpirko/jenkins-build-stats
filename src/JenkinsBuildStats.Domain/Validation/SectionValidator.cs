using FluentValidation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Domain.Validation
{
    public class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(section => section.Name)
                .NotEmpty()
                .WithMessage("Section Name is empty");
        }
    }
}
