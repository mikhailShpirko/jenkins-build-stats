using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Domain.Requests;
using JenkinsBuildStats.Domain.Responses;
using MediatR;

namespace JenkinsBuildStats.Domain.Handlers
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
