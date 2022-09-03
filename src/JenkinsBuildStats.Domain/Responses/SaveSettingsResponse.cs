using JenkinsBuildStats.Domain.Entities;
using OneOf;
namespace JenkinsBuildStats.Domain.Responses
{
    [GenerateOneOf]
    public partial class SaveSettingsResponse : OneOfBase<SuccessfullySaved<Settings>, ValidationFailed<Settings>, ErrorDuringProcessing>
    {
    }
}
