using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DFacturaVentaDTO (Guid Id, float ValorUnitario, int Cantidad, float IVA, 
        float ValorDescuento, Guid IdProducto, Guid IdFacturaVenta);
    
}
