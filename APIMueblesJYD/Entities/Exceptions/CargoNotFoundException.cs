using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CargoNotFoundException : NotFoundException
    {
        public CargoNotFoundException(Guid cargoId)
            :base ($"El cargo con el Id: {cargoId} no existe en la Base de Datos.") { }
    }
}
