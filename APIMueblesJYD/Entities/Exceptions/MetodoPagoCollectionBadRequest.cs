using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MetodoPagoCollectionBadRequest : BadRequestException
    {
        public MetodoPagoCollectionBadRequest()
        : base("MetodoPago collection sent from a client is null.")
        {
        }
    }
}
