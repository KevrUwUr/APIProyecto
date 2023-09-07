using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaDTO
    {
        public Guid IdPerdida { get; init; }
        public DateTime FechaPerdida { get; init; }
        public int Estado { get; init; }
        public float Total { get; init; }
        public Guid EmpleadoId { get; init; }
    }
}
