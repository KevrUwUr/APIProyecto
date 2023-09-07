using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class FacturaVentaCollectionBadRequest : BadRequestException
{
    public FacturaVentaCollectionBadRequest()
        : base("La colección de factura venta enviada desde un cliente es nula.")
    {
    }
}
