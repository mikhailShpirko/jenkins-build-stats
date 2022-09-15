using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Tests.Requests
{
    public class SaveSettingsRequestTests
    {
        [Fact]
        public void Ctor_SettingPropertyProperlySet()
        {
            var settings = new Settings();
            var request = new SaveSettingsRequest(settings);
            request.Settings.Should().BeSameAs(settings);
        }
    }
}
