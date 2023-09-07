using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ProveedorCollectionBadRequest : BadRequestException
    {
        public ProveedorCollectionBadRequest()
        : base("Supplier collection sent from a client is null.")
        {
        }
    }
}
