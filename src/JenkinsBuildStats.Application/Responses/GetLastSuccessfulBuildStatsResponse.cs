using JenkinsBuildStats.Domain.Entities;
using OneOf;

namespace JenkinsBuildStats.Application.Responses
{
    [GenerateOneOf]
    public partial class GetLastSuccessfulBuildStatsResponse : OneOfBase<LastSuccessfulBuildStats, EntityDoesNotExist<LastSuccessfulBuildStats>, ErrorDuringProcessing>
    {
    }
}
