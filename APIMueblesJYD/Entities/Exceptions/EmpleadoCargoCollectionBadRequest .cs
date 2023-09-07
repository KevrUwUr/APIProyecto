using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class EmpleadoCargoCollectionBadRequest : BadRequestException
    {
        public EmpleadoCargoCollectionBadRequest()
            : base("La colección de cargos-empleados enviada desde un cliente es nula.")
        {
        }
    }
}
