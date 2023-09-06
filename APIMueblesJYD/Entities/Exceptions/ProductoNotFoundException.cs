using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ProductoNotFoundException : NotFoundException
    {
        public ProductoNotFoundException(Guid ProductoId)
           : base($"El producto con el Id: {ProductoId} no existe en la Base de Datos.") { }
    }
}
