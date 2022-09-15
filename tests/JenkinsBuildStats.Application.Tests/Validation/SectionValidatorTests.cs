using FluentValidation.TestHelper;
using JenkinsBuildStats.Application.Validation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Validation
{
    public class SectionValidatorTests
    {
        private readonly SectionValidator _validator = new SectionValidator();

        [Fact]
        public async Task NoName_ShouldHaveValidationErrorForName()
        {
            var model = new Section();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public async Task EmptyName_ShouldHaveValidationErrorForName()
        {
            var model = new Section
            {
                Name = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public async Task NameDefined_ShouldNotHaveValidationErrorForName()
        {
            var model = new Section
            {
                Name = "Section"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
    }
}
