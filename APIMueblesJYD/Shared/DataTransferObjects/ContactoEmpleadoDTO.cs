using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoEmpleadoDTO (int Id, string Telefono, string Direccion, string Email, DateTime FechaCreacion, int EmpleadoId);
    
}
