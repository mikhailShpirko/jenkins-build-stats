using JenkinsBuildStats.Domain.Entities;
using OneOf;
namespace JenkinsBuildStats.Domain.Responses
{
    [GenerateOneOf]
    public partial class GetSettingsResponse : OneOfBase<Settings, EntityDoesNotExist<Settings>, ErrorDuringProcessing>
    {
    }
}
