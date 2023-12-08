using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record HistoricoPreciosDTO
    {
        public Guid IdHistoricoPrecios { get; init; }
        public float PrecioVenta { get; init; }
        public DateTime FechaPrecioInicial { get; init; }
        public DateTime FechaPrecioFinal { get; init; }
        public int Estado { get; init; }
        public Guid ProductoId { get; init; }
    }
}
