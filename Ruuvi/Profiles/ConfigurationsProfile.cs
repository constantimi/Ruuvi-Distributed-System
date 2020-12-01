using Ruuvi.Dtos;
using Ruuvi.Models.Core;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class ConfigurationsProfile : Profile
    {
        public ConfigurationsProfile()
        {
            CreateMap<ServiceAgreement, ServiceConfigurationReadDto>();
        }
    }
}
