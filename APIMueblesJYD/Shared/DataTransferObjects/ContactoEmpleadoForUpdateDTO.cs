using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoEmpleadoForUpdateDTO(int Telefono, string Direccion, string Email, DateTime FechaCreacion)
    {
    }
}
