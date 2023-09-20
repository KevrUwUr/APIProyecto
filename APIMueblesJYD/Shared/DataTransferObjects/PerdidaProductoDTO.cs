using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaProductoDTO
    {
        public float PrecioUnitario { get; init; }
        public int Cantidad { get; init; }
        public string? Motivo { get; init; }
        public Guid IdPerdida { get; init; }
        public Guid ProductoId { get; init; }
    }
}
