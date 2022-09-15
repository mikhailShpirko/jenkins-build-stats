using FluentValidation.TestHelper;
using JenkinsBuildStats.Application.Validation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Validation
{
    public class ProjectValidatorTests
    {
        private readonly ProjectValidator _validator = new ProjectValidator();

        [Fact]
        public async Task NoName_ShouldHaveValidationErrorForName()
        {
            var model = new Project();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public async Task EmptyName_ShouldHaveValidationErrorForName()
        {
            var model = new Project
            {
                Name = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public async Task NameDefined_ShouldNotHaveValidationErrorForName()
        {
            var model = new Project
            {
                Name = "Project"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
    }
}
