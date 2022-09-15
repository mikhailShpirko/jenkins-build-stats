using JenkinsBuildStats.Domain.Entities;
using OneOf;

namespace JenkinsBuildStats.Application.Responses
{
    [GenerateOneOf]
    public partial class GetSettingsResponse : OneOfBase<Settings, EntityDoesNotExist<Settings>, ErrorDuringProcessing>
    {
    }
}
