using FluentValidation.TestHelper;
using JenkinsBuildStats.Application.Validation;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Validation
{
    public class SectionConfigValidatorTests
    {
        private readonly SectionConfigValidator _validator = new SectionConfigValidator();

        [Fact]
        public async Task NoSection_ShouldHaveValidationErrorForSection()
        {
            var model = new SectionConfig();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.Section);
        }

        [Fact]
        public async Task SectionDefined_ShouldNotHaveValidationErrorForSection()
        {
            var model = new SectionConfig
            {
                Section = new Section()
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Section);
        }

        [Fact]
        public async Task NoStartsWith_ShouldHaveValidationErrorForStartsWith()
        {
            var model = new SectionConfig();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.StartsWith);
        }

        [Fact]
        public async Task EmptyStartsWith_ShouldHaveValidationErrorForStartsWith()
        {
            var model = new SectionConfig
            {
                StartsWith = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.StartsWith);
        }

        [Fact]
        public async Task StartsWithDefined_ShouldNotHaveValidationErrorForStartsWith()
        {
            var model = new SectionConfig
            {
                StartsWith = "Valid"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.StartsWith);
        }

        [Fact]
        public async Task NoEndsWith_ShouldHaveValidationErrorForEndsWith()
        {
            var model = new SectionConfig();
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.EndsWith);
        }

        [Fact]
        public async Task EmptyEndsWith_ShouldHaveValidationErrorForEndsWith()
        {
            var model = new SectionConfig
            {
                EndsWith = string.Empty
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldHaveValidationErrorFor(x => x.EndsWith);
        }

        [Fact]
        public async Task EndsWithDefined_ShouldNotHaveValidationErrorForEndsWith()
        {
            var model = new SectionConfig
            {
                EndsWith = "Valid"
            };
            var result = await _validator.TestValidateAsync(model);

            result.ShouldNotHaveValidationErrorFor(x => x.EndsWith);
        }
    }
}
