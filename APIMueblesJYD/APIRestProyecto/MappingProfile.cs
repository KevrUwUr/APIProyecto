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
            CreateMap<CargoForCreationDto, Cargo>();
            CreateMap<CargoForUpdateDTO, Cargo>();


            CreateMap<EmpleadoForCreationDTO, Empleado>();
            CreateMap<EmpleadoCargoForUpdateDTO,  Empleado>();
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(dest => dest.EmpleadoId, opt => opt.MapFrom(src => src.EmpleadoId));

            CreateMap<EmpleadoCargo, EmpleadoCargoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmpleadoCargoId));
            CreateMap<EmpleadoCargoForCreationDTO, Empleado>();
            CreateMap<EmpleadoCargoForUpdateDTO, Empleado>();

            CreateMap<Categoria, CategoriaDTO>();

        }
    }
}
