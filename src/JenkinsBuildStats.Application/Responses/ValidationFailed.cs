using FluentValidation.Results;

namespace JenkinsBuildStats.Application.Responses
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
