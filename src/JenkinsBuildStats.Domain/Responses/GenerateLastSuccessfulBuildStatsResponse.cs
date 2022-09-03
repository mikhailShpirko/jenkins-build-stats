using JenkinsBuildStats.Domain.Entities;
using OneOf;
namespace JenkinsBuildStats.Domain.Responses
{
    [GenerateOneOf]
    public partial class GenerateLastSuccessfulBuildStatsResponse : OneOfBase<SuccessfullySaved<LastSuccessfulBuildStats>, EntityDoesNotExist<Settings>, ErrorDuringProcessing>
    {
    }
}
