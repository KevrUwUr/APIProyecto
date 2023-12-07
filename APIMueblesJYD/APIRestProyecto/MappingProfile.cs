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
            CreateMap<CargoForUpdateDTO, Cargo>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdCategoria));
            CreateMap<CategoriaForCreationDTO, Categoria>();
            CreateMap<CategoriaForUpdateDTO, Categoria>();

            CreateMap<ContactoEmpleado, ContactoEmpleadoDTO>()
                .ForMember(dest => dest.ContEmpId, opt => opt.MapFrom(src => src.IdContactoEmpleado));
            CreateMap<ContactoEmpleadoForCreationDTO, ContactoEmpleado>();
            CreateMap<ContactoEmpleadoForUpdateDTO, ContactoEmpleado>().ReverseMap();

            CreateMap<ContactoProveedor, ContactoProveedorDTO>()
                .ForMember(dest => dest.ContProvId, opt => opt.MapFrom(src => src.IdContactoProveedor));
            CreateMap<ContactoProveedorForCreationDTO, ContactoProveedor>();
            CreateMap<ContactoProveedorForUpdateDTO, ContactoProveedor>().ReverseMap();

            CreateMap<ContactoUsuario, ContactoUsuarioDTO>()
                .ForMember(dest => dest.ContUsuarioId, opt => opt.MapFrom(src => src.IdContactoUsuario));
            CreateMap<ContactoUsuarioForCreationDTO, ContactoUsuario>();
            CreateMap<ContactoUsuarioForUpdateDTO, ContactoUsuario>().ReverseMap();

            CreateMap<FacturaVenta, FacturaVentaDTO>()
                .ForMember(dest => dest.FacturaVentaId, opt => opt.MapFrom(src => src.FacturaVentaId));
            CreateMap<FacturaVentaForCreationDTO, FacturaVenta>();
            CreateMap<FacturaVentaForUpdateDTO, FacturaVenta>().ReverseMap();

            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(dest => dest.EmpleadoId, opt => opt.MapFrom(src => src.EmpleadoId));
            CreateMap<EmpleadoForCreationDTO, Empleado>();
            CreateMap<EmpleadoForUpdateDTO, Empleado>();

            CreateMap<MetodoPago, MetodoPagoDTO>()
                .ForMember(dest => dest.IdMetodoPago, opt => opt.MapFrom(src => src.IdMetodoPago));
            CreateMap<MetodoPagoForCreationDTO, MetodoPago>();
            CreateMap<MetodoPagoForUpdateDTO, MetodoPago>().ReverseMap();

            CreateMap<Perdida, PerdidaDTO>()
                .ForMember(dest => dest.IdPerdida, opt => opt.MapFrom(src => src.IdPerdida));
            CreateMap<PerdidaForCreationDTO, Perdida>();
            CreateMap<PerdidaForUpdateDTO, Perdida>();

            CreateMap<PerdidaProducto, PerdidaProductoDTO>();
            CreateMap<PerdidaProductoForCreationDTO, PerdidaProducto>();
            CreateMap<PerdidaProductoForUpdateDTO, PerdidaProducto>();

            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId));
            CreateMap<ProductoForCreationDTO, Producto>();
            CreateMap<ProductoForUpdateDTO, Producto>().ReverseMap();

            CreateMap<Proveedor, ProveedorDTO>()
                .ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.IdProveedor));
            CreateMap<ProveedorForCreationDTO, Proveedor>();
            CreateMap<ProveedorForUpdateDTO, Proveedor>();

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario));
            CreateMap<UsuarioForCreationDTO, Usuario>();
            CreateMap<UsuarioForUpdateDTO, Usuario>();
        }
    }
}
