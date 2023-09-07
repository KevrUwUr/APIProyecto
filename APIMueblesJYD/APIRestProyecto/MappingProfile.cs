using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace APIRestProyecto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cargo, CargoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CargoId));
    
            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
