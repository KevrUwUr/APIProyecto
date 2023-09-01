using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PerdidaDTO(int IdPerdida, DateTime FechaPerdida, int Estado, float Total, int EmpleadoId);

}
