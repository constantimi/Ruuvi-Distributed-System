using Ruuvi.Dtos.Core;
using Ruuvi.Models.Core.ServiceAgreement;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class ConstrainsProfile : Profile
    {
        public ConstrainsProfile()
        {
            CreateMap<Agreement, AgreementReadDto>();
            CreateMap<AgreementCreateDto, Agreement>();
            CreateMap<Agreement, AgreementCreateDto>();
        }
    }
}
