using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ProveedorNotFoundException : NotFoundException
    {
        public ProveedorNotFoundException(Guid IdProveedor)
           : base($"El proveedor con el Id: {IdProveedor} no existe en la Base de Datos.") { }
    }
}
