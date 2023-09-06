using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PerdidaProductoNotFoundException : NotFoundException
    {
        public PerdidaProductoNotFoundException(Guid PerdidaProductoId)
           : base($"La perdida de productocon el Id: {PerdidaProductoId} no existe en la Base de Datos.") { }
    }
}
