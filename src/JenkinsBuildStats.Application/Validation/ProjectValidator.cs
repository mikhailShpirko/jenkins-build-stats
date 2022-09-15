using FluentValidation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Validation
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(project => project.Name)
                .NotEmpty()
                .WithMessage("Project Name is empty");
        }
    }
}
