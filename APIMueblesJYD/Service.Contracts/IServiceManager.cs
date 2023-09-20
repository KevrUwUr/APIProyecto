using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICargoService CargoService { get; }
        ICategoriaService CategoriaService { get; }
        IContactoEmpleadoService ContactoEmpleadoService { get; }
        IContactoProveedorService ContactoProveedorService { get;}
        IContactoUsuarioService ContactoUsuarioService { get; }
        IDetFacturaCompraService DetFacturaCompraService { get; }
        IDetFacturaVentaService DetFacturaVentaService { get; }
        IEmpleadoCargoService EmpleadoCargoService { get; }
        IEmpleadoService EmpleadoService { get; }
        IFacturaCompraService FacturaCompraService { get; }
        IFacturaVentaService FacturaVentaService { get;}
        IHistoricoPreciosService HistoricoPreciosService { get; }
        IMetodoPagoService MetodoPagoService { get; }
        IPerdidaProductoService PerdidaProductoService { get; }
        IPerdidaService PerdidaService { get; }
        IProductoService ProductoService { get; }
        IProveedorService ProveedorService { get; }
        IUsuarioService UsuarioService { get; }
    }
}
