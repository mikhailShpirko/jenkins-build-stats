using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class JenkinsClientConfigProfile : Profile
    {
        public JenkinsClientConfigProfile()
        {
            CreateMap<JenkinsClientConfig, JenkinsClientConfigDTO>();
            CreateMap<JenkinsClientConfigDTO, JenkinsClientConfig>();
        }
    }
}
