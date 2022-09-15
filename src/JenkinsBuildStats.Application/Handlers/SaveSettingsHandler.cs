using FluentValidation;
using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Domain.Entities;
using MediatR;

namespace JenkinsBuildStats.Application.Handlers
{
    public class SaveSettingsHandler : IRequestHandler<SaveSettingsRequest, SaveSettingsResponse>
    {
        private readonly ISettingsRepo _repo;
        private readonly IValidator<Settings> _validator;
        public SaveSettingsHandler(ISettingsRepo repo,
            IValidator<Settings> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<SaveSettingsResponse> Handle(SaveSettingsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) 
                {
                    return new ErrorDuringProcessing(new ArgumentNullException(nameof(request)));
                }

                if (request.Settings is null)
                {
                    return new ErrorDuringProcessing(new ArgumentNullException(nameof(request.Settings)));
                }

                var validationResult = await _validator.ValidateAsync(request.Settings, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return new ValidationFailed<Settings>(validationResult.Errors);
                }

                await _repo.SaveAsync(request.Settings, cancellationToken);

                return new SuccessfullySaved<Settings>();
            }
            catch (Exception e)
            {
                return new ErrorDuringProcessing(e);
            }
        }
    }
}
