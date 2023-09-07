using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ProductoNotFoundException : NotFoundException
    {
        public ProductoNotFoundException(Guid IdProducto)
           : base($"El producto con el Id: {IdProducto} no existe en la Base de Datos.") { }
    }
}
