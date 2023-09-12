using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaProductoForCreationDTO
    {
        public float PrecioUnitario { get; init; }
        public int Cantidad { get; init; }
        public string Motivo { get; init; }
    }

}
