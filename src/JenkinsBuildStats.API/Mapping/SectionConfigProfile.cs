using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class SectionConfigProfile : Profile
    {
        public SectionConfigProfile()
        {
            CreateMap<SectionConfig, SectionConfigDTO>();
            CreateMap<SectionConfigDTO, SectionConfig>();
        }
    }
}
