using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ContactoEmpleadoNotFoundException : NotFoundException
    {
        public ContactoEmpleadoNotFoundException(Guid IdContactoEmpleado)
            : base($"El contacto empleado con el Id: {IdContactoEmpleado} no existe en la Base de Datos.") { }
        }
}
