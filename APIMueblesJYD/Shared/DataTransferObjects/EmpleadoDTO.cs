using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmpleadoDTO (Guid Id, string Nombres, string Apellidos, string Sexo, DateTime FechaNacimiento, int Estado);
    
}
