using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class HistoricoPreciosNotFoundException : NotFoundException
    {
        public HistoricoPreciosNotFoundException(Guid IdHistoricoPrecios)
           : base($"El historico de precios con el Id: {IdHistoricoPrecios} no existe en la Base de Datos.") { }
    }
}
