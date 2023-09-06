using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CategoriaNotFoundException : NotFoundException
    {
        public CategoriaNotFoundException(Guid IdCategoria)
            : base($"La categoria con el Id: {IdCategoria} no existe en la Base de Datos.") { }
    }
}
