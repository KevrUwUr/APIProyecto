using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MetodoPagoDTO(int IdMetodoPago, DateTime FechaTransaccion, int Tipo, string NombrePlataforma, int FacturaVentaId);

}
