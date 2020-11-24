using Ruuvi.Dtos;
using Ruuvi.Models.Data;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class ConfigurationsProfile : Profile
    {
        public ConfigurationsProfile()
        {
            CreateMap<Configuration, ConfigurationReadDto>();
        }
    }
}
