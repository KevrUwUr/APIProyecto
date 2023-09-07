using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class FacturaCompraNotFoundException : NotFoundException
    {
        public FacturaCompraNotFoundException(Guid IdFacturaCompra)
           : base($"La factura de compra con el Id: {IdFacturaCompra} no existe en la Base de Datos.") { }
    }
}
