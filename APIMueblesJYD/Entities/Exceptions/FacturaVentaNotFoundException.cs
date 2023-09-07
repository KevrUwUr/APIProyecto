using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class FacturaVentaNotFoundException : NotFoundException
    {
        public FacturaVentaNotFoundException(Guid IdFacturaVenta)
           : base($"La factura de venta con el Id: {IdFacturaVenta} no existe en la Base de Datos.") { }
    }
}
