using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PerdidaNotFoundException : NotFoundException
    {
        public PerdidaNotFoundException(Guid IdPerdida)
           : base($"La perdida con el Id: {IdPerdida} no existe en la Base de Datos.") { }
    }
}
