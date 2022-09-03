using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    public class JenkinsClientConfigProfile : Profile
    {
        public JenkinsClientConfigProfile()
        {
            CreateMap<JenkinsClientConfig, JenkinsClientConfigDTO>();
            CreateMap<JenkinsClientConfigDTO, JenkinsClientConfig>();
        }
    }
}
