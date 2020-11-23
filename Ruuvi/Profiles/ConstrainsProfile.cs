using Ruuvi.Dtos;
using Ruuvi.Models.Data;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class ConstrainsProfile : Profile
    {
        public ConstrainsProfile()
        {
            CreateMap<Constrain, ConstrainReadDto>();
            CreateMap<ConstrainCreateDto, Constrain>();
            CreateMap<Constrain, ConstrainCreateDto>();
        }
    }
}
