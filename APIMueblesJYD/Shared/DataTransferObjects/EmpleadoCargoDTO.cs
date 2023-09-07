using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmpleadoCargoDTO
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int NumeroContrato { get; set; }
        public Guid EmpleadoId { get; }
        public Guid CargoId { get; }
    }   
}
