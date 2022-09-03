using FluentValidation.Results;

namespace JenkinsBuildStats.Domain.Responses
{
    public class ValidationFailed<T>
    {
        public readonly IReadOnlyCollection<ValidationFailure> Errors;

        public ValidationFailed(List<ValidationFailure> errors)
        {
            Errors = errors.AsReadOnly();
        }
    }
}
