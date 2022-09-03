using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Domain.Requests;

namespace JenkinsBuildStats.Domain.Tests.Requests
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
