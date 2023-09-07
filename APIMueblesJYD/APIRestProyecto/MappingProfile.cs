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
    
            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdCategoria));

            CreateMap<MetodoPago, MetodoPagoDTO>()
                .ForMember(dest => dest.IdMetodoPago, opt => opt.MapFrom(src => src.IdMetodoPago));

            CreateMap<PerdidaProducto, PerdidaProductoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdPerdida));//

            CreateMap<Perdida, PerdidaDTO>()
                .ForMember(dest => dest.IdPerdida, opt => opt.MapFrom(src => src.IdPerdida));

            CreateMap<Proveedor, ProveedorDTO>()
                .ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.IdProveedor));

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario));
        }
    }
}
