using Ruuvi.Dtos.Core;
using Ruuvi.Models.Core.ServiceAgreement;

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
