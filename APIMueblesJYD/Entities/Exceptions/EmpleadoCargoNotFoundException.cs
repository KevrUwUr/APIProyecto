using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class EmpleadoCargoNotFoundException : NotFoundException
    {
        public EmpleadoCargoNotFoundException(int NumeroContrato)
            : base($"El empleado con el numero de contrato: {NumeroContrato} no existe en la Base de Datos.") { }
    }
}
