using FluentValidation.Results;

namespace JenkinsBuildStats.Application.Responses
{
    public sealed record ValidationFailed<T>
    {
        public IReadOnlyCollection<ValidationFailure> Errors { get; }

        public ValidationFailed(List<ValidationFailure> errors)
        {
            Errors = errors.AsReadOnly();
        }
    }
}
