using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ContactoUsuarioNotFoundException : NotFoundException
    {
        public ContactoUsuarioNotFoundException(Guid IdContactoCliente)
            : base($"El contacto usuario con el Id: {IdContactoCliente} no existe en la Base de Datos."){}
    }
}
