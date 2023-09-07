using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CargoCollectionBadRequest : BadRequestException
    {
        public CargoCollectionBadRequest()
            : base("La coleccion de compañias enviada por el usuario es nula")
        {

        }
    }
}
