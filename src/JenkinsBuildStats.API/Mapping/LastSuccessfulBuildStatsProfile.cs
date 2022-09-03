using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    public class LastSuccessfulBuildStatsProfile : Profile
    {
        public LastSuccessfulBuildStatsProfile()
        {
            CreateMap<LastSuccessfulBuildStats, LastSuccessfulBuildStatsDTO>();
        }
    }
}
