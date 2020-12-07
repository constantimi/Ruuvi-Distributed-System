using Ruuvi.Dtos;
using Ruuvi.Models.Core;
using Ruuvi.Models.Data;

using AutoMapper;

namespace Ruuvi.Profiles
{
    public class TagsProfile : Profile
    {
        public TagsProfile()
        {
            CreateMap<RuuviStation, TagReadDto>();
        }
    }
}
