using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    public class SectionConfigProfile : Profile
    {
        public SectionConfigProfile()
        {
            CreateMap<SectionConfig, SectionConfigDTO>();
            CreateMap<SectionConfigDTO, SectionConfig>();
        }
    }
}
