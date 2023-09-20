using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmpleadoCargoForCreationDTO(DateTime FechaInicio, DateTime FechaFin, int NumeroContrato, int EmpleadoId, int CargoId);

}
