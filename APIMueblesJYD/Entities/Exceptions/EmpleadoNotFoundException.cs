using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class EmpleadoNotFoundException : NotFoundException
    {
        public EmpleadoNotFoundException(Guid EmpleadoId)
           : base($"El empleado con el Id: {EmpleadoId} no existe en la Base de Datos.") { }
    }
}
