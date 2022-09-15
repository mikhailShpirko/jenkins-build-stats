using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Domain.Entities;
using MediatR;

namespace JenkinsBuildStats.Application.Handlers
{
    public sealed class GetSettingsHandler : IRequestHandler<GetSettingsRequest, GetSettingsResponse>
    {
        private readonly ISettingsRepo _repo;
        public GetSettingsHandler(ISettingsRepo repo)
        {
            _repo = repo;
        }

        public async Task<GetSettingsResponse> Handle(GetSettingsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var settings = await _repo.GetAsync(cancellationToken);

                if (settings is null)
                {
                    return new EntityDoesNotExist<Settings>();
                }

                return settings;
            }
            catch (Exception e)
            {
                return new ErrorDuringProcessing(e);
            }
        }
    }
}
