using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class LastSuccessfulBuildStatsProfile : Profile
    {
        public LastSuccessfulBuildStatsProfile()
        {
            CreateMap<LastSuccessfulBuildStats, LastSuccessfulBuildStatsDTO>();
        }
    }
}
