using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Domain.Entities;
using MediatR;

namespace JenkinsBuildStats.Application.Handlers
{
    public class GetLastSuccessfulBuildStatsHandler : IRequestHandler<GetLastSuccessfulBuildStatsRequest, GetLastSuccessfulBuildStatsResponse>
    {
        private readonly ILastSuccessfulBuildStatsRepo _repo;
        public GetLastSuccessfulBuildStatsHandler(ILastSuccessfulBuildStatsRepo repo)
        {
            _repo = repo;
        }

        public async Task<GetLastSuccessfulBuildStatsResponse> Handle(GetLastSuccessfulBuildStatsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var buildStats = await _repo.GetAsync(cancellationToken);

                if (buildStats is null)
                {
                    return new EntityDoesNotExist<LastSuccessfulBuildStats>();
                }

                return buildStats;
            }
            catch (Exception e)
            {
                return new ErrorDuringProcessing(e);
            }
        }
    }
}
