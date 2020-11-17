using Ruuvi.Dtos;
using Ruuvi.Models.Data;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class BoundariesProfile : Profile
    {
        public BoundariesProfile()
        {
            CreateMap<Boundary, BoundaryReadDto>();
            CreateMap<BoundaryCreateDto, Boundary>();
            CreateMap<Boundary, BoundaryCreateDto>();
        }
    }
}
