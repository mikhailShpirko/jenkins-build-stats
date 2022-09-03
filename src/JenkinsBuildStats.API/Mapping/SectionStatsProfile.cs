using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    public class SectionStatsProfile : Profile
    {
        public SectionStatsProfile()
        {
            CreateMap<SectionStats, SectionStatsDTO>();
        }
    }
}
