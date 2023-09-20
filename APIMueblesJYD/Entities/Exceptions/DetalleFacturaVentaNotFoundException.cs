using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class DetalleFacturaVentaNotFoundException : NotFoundException
    {
        public DetalleFacturaVentaNotFoundException(Guid DetalleFacturaVentaID)
           : base($"El detalle de factura de compra con el Id: {DetalleFacturaVentaID} no existe en la Base de Datos.") { }
    }
}
