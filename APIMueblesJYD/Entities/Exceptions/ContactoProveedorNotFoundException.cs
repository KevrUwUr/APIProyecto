using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ContactoProveedorNotFoundException : NotFoundException
    {
        public ContactoProveedorNotFoundException(Guid IdContactoProveedor)
            : base($"El contacto proveedor con el Id: {IdContactoProveedor} no existe en la Base de Datos.") { }
    }
}
