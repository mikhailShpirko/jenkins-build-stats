using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDTO>();
            CreateMap<SectionDTO, Section>();
        }
    }
}
