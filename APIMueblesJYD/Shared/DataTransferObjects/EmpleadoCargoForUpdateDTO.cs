using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmpleadoCargoForUpdateDTO(DateTime FechaInicio, DateTime FechaFin, int NumeroContrato, Guid EmpleadoId, Guid CargoId)
    {
    }
}
