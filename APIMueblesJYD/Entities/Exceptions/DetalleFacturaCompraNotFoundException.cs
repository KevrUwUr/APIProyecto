using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class DetalleFacturaCompraNotFoundException : NotFoundException
    {
        public DetalleFacturaCompraNotFoundException(Guid DetalleacturaCompraId)
           : base($"El detalle de factura de compra con el Id: {DetalleacturaCompraId} no existe en la Base de Datos.") { }
    }
}
