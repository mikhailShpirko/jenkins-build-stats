using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class SectionStatsProfile : Profile
    {
        public SectionStatsProfile()
        {
            CreateMap<SectionStats, SectionStatsDTO>();
        }
    }
}
