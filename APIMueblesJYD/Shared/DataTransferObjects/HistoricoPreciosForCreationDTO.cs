using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record HistoricoPreciosForCreationDTO(float PrecioVenta, 
        DateTime FechaPrecioInicial, DateTime FechaPrecioFinal, int Estado);
}
