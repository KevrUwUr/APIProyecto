using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MetodoPagoNotFoundException : NotFoundException
    {
        public MetodoPagoNotFoundException(Guid IdMetodoPago)
           : base($"El metodo de pago con el Id: {IdMetodoPago} no existe en la Base de Datos.") { }
    }
}
