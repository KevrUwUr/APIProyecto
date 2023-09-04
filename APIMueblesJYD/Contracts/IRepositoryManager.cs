using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICargoRepository Cargo {  get; }
        ICategoriaRepository Categoria { get; }
        IContactoEmpleadoRepository ContactoEmpleado { get; }
        IContactoProveedorRepository ContactoProveedor { get; }
        IContactoUsuarioRepository ContactoUsuario { get; }
        IDetFacturaCompraRepository DetFacturaCompra { get; }
        IDetFacturaVentaRepository DetFacturaVenta { get; }
        IEmpleadoCargoRepository EmpleadoCargo { get; }
        IEmpleadoRepository Empleado { get; }
        IFacturaCompraRepository FacturaCompra { get; }
        IFacturaVentaRepository FacturaVenta { get; }
        IHistoricoPreciosRepository HistoricoPrecios { get; }
        IMetodoPagoRepository MetodoPago { get; }
        IPerdidaProductoRepository PerdidaProducto { get; }
        IPerdidaRepository Perdida { get; }
        IProductoRepository Producto { get; }
        IProveedorRepository Proveedor { get; }
        IUsuarioRepository Usuario { get; }
        void Save();
    }
}
