using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DFacturaCompraDTO
    {
        public float ValorUnitario { get; init; }
        public int Cantidad { get; init; }
        public float IVA { get; init; }
        public float ValorDescuentoint { get; init; }
        public Guid FacturaCompraId { get; init; }
        public Guid ProductoId { get; init; }
    }
}
