using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoEmpleadoDTO (Guid Id, int Telefono, string Direccion, string Email, DateTime FechaCreacion, Guid IdEmpleado);
    
}
