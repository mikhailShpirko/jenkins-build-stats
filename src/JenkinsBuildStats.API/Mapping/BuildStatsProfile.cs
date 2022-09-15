using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class BuildStatsProfile : Profile
    {
        public BuildStatsProfile()
        {
            CreateMap<BuildStats, BuildStatsDTO>();
        }
    }
}
