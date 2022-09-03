using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Infrastructure.DataStorage;

namespace JenkinsBuildStats.Infrastructure.Repos
{
    public class LastSuccessfulBuildStatsRepoFileRepo : 
        BaseFileRepo<LastSuccessfulBuildStats>,
        ILastSuccessfulBuildStatsRepo
    {
        public LastSuccessfulBuildStatsRepoFileRepo(IFileStorage fileStorage)
            : base (fileStorage, nameof(LastSuccessfulBuildStats))
        {
        }
    }
}
