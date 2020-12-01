using Ruuvi.Dtos;
using Ruuvi.Models.Core;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class ConstrainsProfile : Profile
    {
        public ConstrainsProfile()
        {
            CreateMap<Agreement, AgreementConstrainReadDto>();
            CreateMap<AgreementConstrainCreateDto, Agreement>();
            CreateMap<Agreement, AgreementConstrainCreateDto>();
        }
    }
}
