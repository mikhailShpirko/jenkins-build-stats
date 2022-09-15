using AutoMapper;
using JenkinsBuildStats.API.DTO;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.API.Mapping
{
    internal sealed class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<Settings, SettingsDTO>();
            CreateMap<SettingsDTO, Settings>();
        }
    }
}
