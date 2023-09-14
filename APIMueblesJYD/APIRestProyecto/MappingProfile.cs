using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace APIRestProyecto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cargo, CargoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CargoId));

            CreateMap<CargoForCreationDTO, Cargo>();
            CreateMap<CargoForUpdateDTO, Cargo>();

            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdCategoria));

            CreateMap<CategoriaForCreationDTO, Categoria>();
            CreateMap<CategoriaForUpdateDTO, Categoria>();

            CreateMap<ContactoProveedor, ContactoProveedorDTO>()
                .ForMember(dest => dest.ContProvId, opt => opt.MapFrom(src => src.IdContactoProveedor));

            CreateMap<ContactoProveedorForCreationDTO, ContactoProveedor>();
            CreateMap<ContactoProveedorForUpdateDTO, ContactoProveedor>();

            CreateMap<MetodoPago, MetodoPagoDTO>()
                .ForMember(dest => dest.IdMetodoPago, opt => opt.MapFrom(src => src.IdMetodoPago));

            CreateMap<MetodoPagoForCreationDTO, MetodoPago>();
            CreateMap<MetodoPagoForUpdateDTO, MetodoPago>();

            CreateMap<PerdidaProducto, PerdidaProductoDTO>();

            CreateMap<PerdidaProductoForCreationDTO, PerdidaProducto>();
            CreateMap<PerdidaProductoForUpdateDTO, PerdidaProducto>();

            CreateMap<Perdida, PerdidaDTO>()
                .ForMember(dest => dest.IdPerdida, opt => opt.MapFrom(src => src.IdPerdida));

            CreateMap<PerdidaForCreationDTO, Perdida>();
            CreateMap<PerdidaForUpdateDTO, Perdida>();

            CreateMap<Proveedor, ProveedorDTO>()
                .ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.IdProveedor));

            CreateMap<ProveedorForCreationDTO, Proveedor>();
            CreateMap<ProveedorForUpdateDTO, Proveedor>();

            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId));

            CreateMap<ProductoForCreationDTO, Producto>();
            CreateMap<ProductoForUpdateDTO, Producto>();

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario));
        }
    }
}
