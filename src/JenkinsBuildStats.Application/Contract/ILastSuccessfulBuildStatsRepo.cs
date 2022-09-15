using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Contract
{
    public interface ILastSuccessfulBuildStatsRepo : IRepo<LastSuccessfulBuildStats>
    {
    }
}
