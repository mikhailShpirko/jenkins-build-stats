using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    public class BuildStatsProfile : Profile
    {
        public BuildStatsProfile()
        {
            CreateMap<BuildStats, BuildStatsDTO>();
        }
    }
}
