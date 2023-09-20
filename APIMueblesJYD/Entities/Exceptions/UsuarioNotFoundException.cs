using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UsuarioNotFoundException : NotFoundException
    {
        public UsuarioNotFoundException(Guid IdUsuario)
           : base($"El usuario con el Id: {IdUsuario} no existe en la Base de Datos.") { }
    }
}
