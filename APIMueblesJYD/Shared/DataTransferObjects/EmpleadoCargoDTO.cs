using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmpleadoCargoDTO
    {
        public Guid Id { get; init; }
        public DateTime FechaInicio { get; init; }
        public DateTime FechaFin { get; init; }
        public int NumeroContrato { get; init; }
        public Guid EmpleadoId { get; init; }
        public Guid CargoId { get; init; }
    }   
}
