using Ruuvi.Dtos;
using Ruuvi.Models.Core;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class RoutesProfile : Profile
    {
        public RoutesProfile()
        {
            CreateMap<Route, RouteReadDto>();
            CreateMap<RouteCreateDto, Route>();
            CreateMap<Route, RouteCreateDto>();
        }
    }
}
