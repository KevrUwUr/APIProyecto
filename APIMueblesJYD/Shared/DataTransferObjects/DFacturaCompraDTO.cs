using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DFacturaCompraDTO (int Id, float ValorUnitario, int Cantidad, float IVA, 
        float ValorDescuento, int IdFacturaCompra, int IdProducto);
}
